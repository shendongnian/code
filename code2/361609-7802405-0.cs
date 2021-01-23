    WebClient client1 = new WebClient();
    string path = "dtscompleted.php";//your php path
    NameValueCollection formData = new NameValueCollection();
    byte[] responseBytes2=null;
    formData.Add("key", "123");
    try
     {
          responseBytes2 = client1.UploadValues(path, "POST", formData);
     }
    catch (WebException web)
     {
          //MessageBox.Show("Check network connection.\n"+web.Message);
     }
