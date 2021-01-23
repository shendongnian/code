    private static WebClient client = new WebClient();
    private static NameValueCollection nvc= new NameValueCollection();
    nvc.Add(POST_ACTION, ACTION_CODE_LOGIN);
    nvc.Add(POST_EMAIL, email);
    nvc.Add(POST_PASSWORD, password);
    
    sResponse = System.Text.Encoding.ASCII.GetString(client.UploadValues(BASE_URL + ACTION_PAGE, nvc));
