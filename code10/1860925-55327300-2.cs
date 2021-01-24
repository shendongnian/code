    public static class TokenService
    {
        public static int expireTime = 20;
        public static string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            var key = Guid.NewGuid().ToString();
            var salt = "somesalt";          
            byte[] securedKey = Encoding.ASCII.GetBytes(key + salt);
            string token = Convert.ToBase64String(time.Concat(securedKey).ToArray());
            return token;
        }
        public static bool IsValidToken(string token)
        {
            try
            {
                byte[] data = Convert.FromBase64String(token);
                //default expire time is 20 mins
               
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                if (when < DateTime.UtcNow.AddMinutes(-expireTime))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                new Exception("Unauthorized!");
            }
            return false;
        }
    }
