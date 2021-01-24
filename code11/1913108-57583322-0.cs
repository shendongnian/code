    private class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public static UserInfo Parse(string url)
        {
            var parts = url.Split('?', '&');
            var userInfo = new UserInfo();
            foreach (var part in parts)
            {
                if (part.StartsWith("username", StringComparison.OrdinalIgnoreCase) &&
                    part.Contains('='))
                {
                    userInfo.UserName = part.Split('=')[1];
                }
                else if (part.StartsWith("password", StringComparison.OrdinalIgnoreCase) &&
                    part.Contains('='))
                {
                    userInfo.Password = part.Split('=')[1];
                }
            }
            return userInfo;
        }
        public override string ToString()
        {
            return $"User name: {UserName}, Password: {Password}";
        }
    }
