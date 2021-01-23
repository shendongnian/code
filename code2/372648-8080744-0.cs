    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
    client.Timeout = 3000;
    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    client.Host = "smtp.gmail.com";
    client.Port = 587;
    
    System.Net.NetworkCredential myCreds = new System.Net.NetworkCredential(
         "Your@emailhere.com"
         "YourPasswordHere"
                    "");
    
    
    client.Credentials = myCreds;
    client.EnableSsl = true;
    
    client.Send(message);
