    public static bool Update(NameValueCollection nameValueCollection)
    {
        using (WebClient client = new WebClient())
        {
            string result = Encoding.UTF8.GetString(client.UploadValues($"{Domain}/API.php", nameValueCollection));
            dynamic json = JsonConvert.DeserializeObject(result);
            if (json.result == "success")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
