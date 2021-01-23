    public string GetEncryptedCookieValue(string cookieKey)
    {
        using (var aes = new AesManaged())
        {
            aes.Key = new byte[0];//TODO: Replace this with getting the secret key.
            aes.IV = new byte[0];//TODO: Replace this with getting the secret IV.
            var cookie = Request.Cookies[cookieKey];
            var data = Convert.FromBase64String(cookie.Value);
            using (var transform = aes.CreateDecryptor())
            {
                var clearData = transform.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF8.GetString(clearData);
            }
        }
    }
    public void SetEncryptedCookieValue(string cookieKey, string value)
    {
        using (var aes = new AesManaged())
        {
            aes.Key = new byte[0];//TODO: Replace this with getting the secret key.
            aes.IV = new byte[0];//TODO: Replace this with getting the secret IV.
            var clearData = Encoding.UTF8.GetBytes(value);
            using (var transform = aes.CreateEncryptor())
            {
                var data = transform.TransformFinalBlock(clearData, 0, clearData.Length);
                Response.SetCookie(new HttpCookie(cookieKey, Convert.ToBase64String(data)));
            }
        } 
    }
