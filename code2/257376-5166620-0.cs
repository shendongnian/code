    System.Configuration.ConfigurationSection sec = System.Configuration.ConfigurationManager.GetSection("facebookSettings");
    Facebook.FacebookConfigurationSection _config = (sec as Facebook.FacebookConfigurationSection); 
    if (!string.IsNullOrEmpty(TextBox1.Text))
        _config.AppID = TextBox1.Text.ToString();
    if (!string.IsNullOrEmpty(TextBox2.Text))
        _config.AppSecret = TextBox2.Text.ToString();
    if (!string.IsNullOrEmpty(TextBox3.Text))
        _config.CanvasPage = TextBox3.Text.ToString();
    if (!string.IsNullOrEmpty(TextBox4.Text))
        _config.CanvasUrl = TextBox4.Text.ToString();
    _config.CancelUrlPath = "";
    config.Save();
