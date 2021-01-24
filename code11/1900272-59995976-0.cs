	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using System.Web;
	namespace SameSiteHttpModule
	{
		public class SameSiteModule : IHttpModule
		{
			// Suffix includes a randomly generated code to minimize possibility of cookie copies colliding with original names
			private const string SuffixForCookieCopy = "-same-site-j4J6bSt0";
			private Regex _cookieNameRegex;
			private Regex _cookieSameSiteAttributeRegex;
			private Regex _cookieSecureAttributeRegex;
			/// <inheritdoc />
			/// <summary>
			///     Set up the event handlers.
			/// </summary>
			public void Init(HttpApplication context)
			{
				// Initialize regular expressions used for making a cookie copy
				InitializeMatchExpressions();
				// This one is the OUTBOUND side; we add the extra cookies
				context.PreSendRequestHeaders += OnPreSendRequestHeaders;
				// This one is the INBOUND side; we coalesce the cookies
				context.BeginRequest += OnBeginRequest;
			}
			/// <summary>
			///     The OUTBOUND LEG; we add the extra cookie
			/// </summary>
			private void OnPreSendRequestHeaders(object sender, EventArgs e)
			{
				var application = (HttpApplication) sender;
				var response = application.Context.Response;
				var cookieCopies = CreateCookieCopiesToSave(response);
				SaveCookieCopies(response, cookieCopies);
			}
			/// <summary>
			///     The INBOUND LEG; we coalesce the cookies
			/// </summary>
			private void OnBeginRequest(object sender, EventArgs e)
			{
				var application = (HttpApplication) sender;
				var request = application.Context.Request;
				var cookiesToRestore = CreateCookiesToRestore(request);
				RestoreCookies(request, cookiesToRestore);
			}
			#region Supporting code for saving cookies
			private IEnumerable<string> CreateCookieCopiesToSave(HttpResponse response)
			{
				var cookieStrings = response.Headers.GetValues("set-cookie") ?? new string[0];
				var cookieCopies = new List<string>();
				foreach (var cookieString in cookieStrings)
				{
					bool createdCopy;
					var cookieStringCopy = TryMakeSameSiteCookieCopy(cookieString, out createdCopy);
					if (!createdCopy) continue;
					cookieCopies.Add(cookieStringCopy);
				}
				return cookieCopies;
			}
			private static void SaveCookieCopies(HttpResponse response, IEnumerable<string> cookieCopies)
			{
				foreach (var cookieCopy in cookieCopies)
				{
					response.Headers.Add("set-cookie", cookieCopy);
				}
			}
			private void InitializeMatchExpressions()
			{
				_cookieNameRegex = new Regex(@"
					(?'prefix'          # Group 1: Everything prior to cookie name
						^\s*                # Start of value followed by optional whitespace
					)
					(?'cookie_name'     # Group 2: Cookie name
						[^\s=]+             # One or more characters that are not whitespace or equals
					)            
					(?'suffix'          # Group 3: Everything after the cookie name
						.*$                 # Arbitrary characters followed by end of value
					)",
					RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
				_cookieSameSiteAttributeRegex = new Regex(@"
					(?'prefix'          # Group 1: Everything prior to SameSite attribute value
						^.*                 # Start of value followed by 0 or more arbitrary characters
						;\s*                # Semicolon followed by optional whitespace
						SameSite            # SameSite attribute name
						\s*=\s*             # Equals sign (with optional whitespace around it)
					)
					(?'attribute_value' # Group 2: SameSite attribute value
						[^\s;]+             # One or more characters that are not whitespace or semicolon
					)
					(?'suffix'          # Group 3: Everything after the SameSite attribute value
						.*$                 # Arbitrary characters followed by end of value
					)",
					RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
				_cookieSecureAttributeRegex = new Regex(@"
					;\s*                # Semicolon followed by optional whitespace
					Secure              # Secure attribute value
					\s*                 # Optional whitespace
					(?:;|$)             # Semicolon or end of value",
					RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
			}
			private string TryMakeSameSiteCookieCopy(string cookie, out bool success)
			{
				if (!AddNameSuffix(ref cookie))
				{
					// could not add the name suffix so unable to copy cookie (generally should not happen)
					success = false;
					return null;
				}
				var addedSameSiteNone = AddSameSiteNone(ref cookie);
				var addedSecure = AddSecure(ref cookie);
				if (!addedSameSiteNone && !addedSecure)
				{
					// cookie already has SameSite and Secure attributes so don't make copy
					success = false;
					return null;
				}
				success = true;
				return cookie;
			}
			private bool AddNameSuffix(ref string cookie)
			{
				var match = _cookieNameRegex.Match(cookie);
				if (!match.Success)
				{
					// Could not find the cookie name in order to modify it
					return false;
				}
				var groups = match.Groups;
				var nameForCopy = groups["cookie_name"] + SuffixForCookieCopy;
				cookie = string.Concat(groups["prefix"].Value, nameForCopy, groups["suffix"].Value);
				return true;
			}
			private bool AddSameSiteNone(ref string cookie)
			{
				var match = _cookieSameSiteAttributeRegex.Match(cookie);
				if (!match.Success)
				{
					cookie += "; SameSite=None";
					return true;
				}
				var groups = match.Groups;
				if (groups["attribute_value"].Value.Equals("None", StringComparison.OrdinalIgnoreCase))
				{
					// SameSite=None is already present, so we will not add it
					return false;
				}
				// Replace existing SameSite value with "None"
				cookie = string.Concat(groups["prefix"].Value, "None", groups["suffix"].Value);
				return true;
			}
			private bool AddSecure(ref string cookie)
			{
				if (_cookieSecureAttributeRegex.IsMatch(cookie))
				{
					// Secure is already present so we will not add it
					return false;
				}
				cookie += "; Secure";
				return true;
			}
			#endregion
			#region Supporting code for restoring cookies
			private static IEnumerable<HttpCookie> CreateCookiesToRestore(HttpRequest request)
			{
				var cookiesToRestore = new List<HttpCookie>();
				for (var i = 0; i < request.Cookies.Count; i++)
				{
					var inboundCookie = request.Cookies[i];
					if (inboundCookie == null) continue;
					var cookieName = inboundCookie.Name;
					if (!cookieName.EndsWith(SuffixForCookieCopy, StringComparison.OrdinalIgnoreCase))
					{
						continue; // Not interested in this cookie since it is not a copied cookie.
					}
					var originalName = cookieName.Substring(0, cookieName.Length - SuffixForCookieCopy.Length);
					if (request.Cookies[originalName] != null)
					{
						continue; // We have the original cookie, so we are OK; just continue.
					}
					cookiesToRestore.Add(new HttpCookie(originalName, inboundCookie.Value));
				}
				return cookiesToRestore;
			}
			private static void RestoreCookies(HttpRequest request, IEnumerable<HttpCookie> cookiesToRestore)
			{
				// We need to inject cookies as if they were the original.
				foreach (var cookie in cookiesToRestore)
				{
					// Add to the cookie header for non-managed modules
					// https://support.microsoft.com/en-us/help/2666571/cookies-added-by-a-managed-httpmodule-are-not-available-to-native-ihtt
					if (request.Headers["cookie"] == null)
					{
						request.Headers.Add("cookie", $"{cookie.Name}={cookie.Value}");
					}
					else
					{
						request.Headers["cookie"] += $"; {cookie.Name}={cookie.Value}";
					}
					// Also add to the request cookies collection for managed modules.
					request.Cookies.Add(cookie);
				}
			}
			#endregion
			public void Dispose()
			{
			}
		}
	}
