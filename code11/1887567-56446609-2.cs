    private readonly IOptions<EmailSettings> _emailSetting;
     
    public EmailSender(IOptions<EmailSettings> emailSetting)
    {
      _emailSetting = emailSetting;
    } 
    
    public string GetConfig(){
        return _emailSetting.Value.SenderName;
    }
