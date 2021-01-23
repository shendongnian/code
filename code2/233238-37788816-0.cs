    public class ReCaptchaAttribute : ActionFilterAttribute
    {
		private readonly string CAPTCHA_URL = "https://www.google.com/recaptcha/api/siteverify";
		private readonly string SECRET = "your_secret";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
			try
			{
				// Get recaptcha value
				var captchaResponse = filterContext.HttpContext.Request.Form["g-recaptcha-response"];
				using (var client = new HttpClient())
				{
					var values = new Dictionary<string, string>
					{
						{ "secret", SECRET },
						{ "response", captchaResponse },
						{ "remoteip", filterContext.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString() }
					};
					var content = new FormUrlEncodedContent(values);
					var result = client.PostAsync(CAPTCHA_URL, content).Result;
					if (result.IsSuccessStatusCode)
					{
						string responseString = result.Content.ReadAsStringAsync().Result;
						var captchaResult = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(responseString);
						if (!captchaResult.Success)
						{
							((Controller)filterContext.Controller).ModelState.AddModelError("ReCaptcha", "Captcha not solved");
						}
					} else
					{
						((Controller)filterContext.Controller).ModelState.AddModelError("ReCaptcha", "Captcha error");
					}
				}
			}
			catch (System.Exception)
			{
				((Controller)filterContext.Controller).ModelState.AddModelError("ReCaptcha", "Unknown error");
			}
		}
    }
