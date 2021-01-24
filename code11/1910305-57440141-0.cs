    public static void OpenWhatsapp(string phoneNumber, string message = null)
            {
                try
                {
                    var uriString = "whatsapp://send?phone=" + phoneNumber;
    
                    if (!string.IsNullOrWhiteSpace(message))
                        uriString += "&text=" + message;
    
                    Device.OpenUri(new Uri(uriString));
    
                }
