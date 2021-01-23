    [HttpGet]
    public bool ValidateRecapcha(string challengetKey, string input)
    {
       var r = new Recaptcha.RecaptchaValidator();
       r.PrivateKey = "Recapcha Private Key"
       r.Challenge = challengetKey;
       r.Response = input;
       r.RemoteIP = "REMOTE_ADDR".ToServerVariables();
       var response = r.Validate();
       return response.IsValid;
    }
