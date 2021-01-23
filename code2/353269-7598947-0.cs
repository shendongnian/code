    using Google.GData.Client;
    public bool Google_Login(string email,string password, string captcha,string captchatoken)
    {
    	String AppName = "MyCompany-MyApp-1.0.0.0";
    	Service s = new Service("code", AppName); //Can use any service, I just happened to want to use GoogleCode
    	s.setUserCredentials(email, password);
    	if(captcha != null && captchatoken != null) //If we already tried to log in, but we needed to captcha
    	{
    		if(!String.IsNullOrWhiteSpace(captcha) || !String.IsNullOrWhiteSpace(captchatoken))
    		{
    			s.Credentials.CaptchaToken = captchatoken;
    			s.Credentials.CaptchaAnswer = captcha;
    		}
    	}
    	try
    	{
    		string ret = s.QueryClientLoginToken();
    		//If we end up here, then the credentials are correct.
    	}
    	catch(Google.GData.Client.CaptchaRequiredException ce)
    	{
    		//ce.Url is the full url of the Captcha image
    		//If you would rather handle the captcha from
    		//a webpage, you can make your user go here "https://www.google.com/accounts/DisplayUnlockCaptcha"
    		
    		//TODO Some way to display the captcha image and get user feedback
    		//we'll just say you did that and returned a string named retCaptcha
    		return Google_Login(email,password, retCaptcha,ce.Token);
    	}
    	catch(Google.GData.Client.AuthenticationException re)
    	{
    		//re.Message is the specific message google sends back about the login attempt.
    		return false;
    	}
    	catch(WebException e)
    	{
    		//Haven't ended up here yet, but I'm sure it's possible.
    		return false;
    	}
    	//If we somehow end up here
    	return false;
    }
