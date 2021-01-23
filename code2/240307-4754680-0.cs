    using System.Web.Security;
    using System.Web;
    namespace Utilities.Helpers
    {
    	/// <summary>
    	/// A helper class that aids us in dealing with the Auth Cookie.
    	/// </summary>
    	/// <remarks></remarks>
    	public sealed class AuthenticationHelper
    	{
    		/// <summary>
    		/// Prevents a default instance of the <see cref="AuthenticationHelper" /> class from being created.
    		/// </summary>
    		/// <remarks></remarks>
    		private AuthenticationHelper()
    		{
    		}
    		/// <summary>
    		/// Generate an Authentication Cookie that also contains "UserData".
    		/// The UserData is a serialized "AuthUserData" Object containing "ID"
    		/// "RegionID" "Username" and "Slug"
    		/// </summary>
    		/// <param name="userName">this is the "claimedidentifier" of the user's OpenId</param>
    		/// <param name="userData">be mindful of the cookie size or you will be chasing ghosts</param>
    		/// <param name="persistent"></param>
    		public static HttpCookie CreateAuthCookie(string userName, AuthUserData userData, bool persistent)
    		{
    
    			DateTime issued = DateTime.UtcNow;
    			// formsAuth does not expose timeout!? have to get around the spoiled
    			// parts and keep moving..
    			HttpCookie fooCookie = FormsAuthentication.GetAuthCookie("foo", true);
    			int formsTimeout = Convert.ToInt32((fooCookie.Expires - DateTime.UtcNow).TotalMinutes);
    
    			DateTime expiration = DateTime.UtcNow.AddMinutes(formsTimeout);
    			string cookiePath = FormsAuthentication.FormsCookiePath;
    
    			string SerializedUser = SerializeUser(userData);
    
    			object ticket = new FormsAuthenticationTicket(0, userName, issued, expiration, true, SerializedUser, cookiePath);
    			return CreateAuthCookie(ticket, expiration, persistent);
    		}
    
    		/// <summary>
    		/// Creates the auth cookie.
    		/// </summary>
    		/// <param name="ticket">The ticket.</param>
    		/// <param name="expiration">The expiration.</param>
    		/// <param name="persistent">if set to <c>true</c> [persistent].</param>
    		/// <returns></returns>
    		/// <remarks></remarks>
    		public static HttpCookie CreateAuthCookie(FormsAuthenticationTicket ticket, DateTime expiration, bool persistent)
    		{
    			string creamyFilling = FormsAuthentication.Encrypt(ticket);
    			object cookie = new HttpCookie(FormsAuthentication.FormsCookieName, creamyFilling) {
    				Domain = FormsAuthentication.CookieDomain,
    				Path = FormsAuthentication.FormsCookiePath
    			};
    			if (persistent) {
    				cookie.Expires = expiration;
    			}
    
    			return cookie;
    		}
    
    
    		/// <summary>
    		/// Retrieves the auth user.
    		/// </summary>
    		/// <returns></returns>
    		/// <remarks></remarks>
    		public static AuthUserData RetrieveAuthUser()
    		{
    			string cookieName = FormsAuthentication.FormsCookieName;
    			HttpCookie authCookie = HttpContext.Current.Request.Cookies(cookieName);
    			FormsAuthenticationTicket authTicket = default(FormsAuthenticationTicket);
    			string userdata = string.Empty;
    			AuthUserData aum = new AuthUserData();  //AuthUserData is a custom serializable Poco that holds all the required user data for my cookie (userID, email address, whatever.
    
    			if ((authCookie != null)) {
    				authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    				userdata = authTicket.UserData;
    			}
    
    			if ((!object.ReferenceEquals(userdata, string.Empty))) {
    				aum = DeserializeUser(userdata);
    				if (string.IsNullOrEmpty(aum.Username)) {
    					aum.Username = "User" + aum.ID;
    				}
    			} else {
    				aum.ID = null;
    				aum.Region = null;
    				aum.Username = string.Empty;
    				aum.Reputation = 0;
    			}
    
    			return aum;
    		}
    
    
    		/// <summary>
    		/// Serializes the user.
    		/// </summary>
    		/// <param name="aum">The AuthUserData.</param>
    		/// <returns></returns>
    		/// <remarks>The AuthUserData is a custom serializable poco that holds the data</remarks>
    		private static string SerializeUser(AuthUserData aud)
    		{
    			Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    			IO.MemoryStream mem = new IO.MemoryStream();
    			bf.Serialize(mem, aud);
    			return Convert.ToBase64String(mem.ToArray());
    		}
    
    		/// <summary>
    		/// Deserializes the user.
    		/// </summary>
    		/// <param name="serializedaum">The serialized AuthUserData.</param>
    		/// <returns></returns>
    		/// <remarks></remarks>
    		private static AuthUserData DeserializeUser(string serializedaud)
    		{
    			Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    			IO.MemoryStream mem = new IO.MemoryStream(Convert.FromBase64String(serializedaud));
    			return (AuthUserData)bf.Deserialize(mem);
    		}
    	}
    }
