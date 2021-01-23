     // Instantiate the WebClient object
     WebClient WHMCSclient = new WebClient();
     // Prepare a Name/Value collection to hold the post values
     NameValueCollection form = new NameValueCollection();		
     form.Add("username", username);
     form.Add("password", password); // the password will still need encoding is MD5 is a requirement
     form.Add("action", "addinvoicepayment"); // action performed by the API:Functions
     form.Add("invoiceid", "1");
     form.Add("transid", "TEST");
     form.Add("gateway", "mailin");
     // Post the data and read the response
     Byte[] responseData = WHMCSclient.UploadValues("http://www.yourdomain.com/whmcs/includes/api.php", form);		
     // Decode and display the response.
     Console.WriteLine("\nResponse received was \n{0}",Encoding.ASCII.GetString(responseData));
