    private static WebClient client = new WebClient();
    private static NameValueCollection collection = new NameValueCollection();
    collection.Add(POST_ACTION, ACTION_CODE_LOGIN);
    collection.Add(POST_EMAIL, email);
    collection.Add(POST_PASSWORD, password);
    
    sResponse = System.Text.Encoding.ASCII.GetString(client.UploadValues(BASE_URL + ACTION_PAGE, collection));
