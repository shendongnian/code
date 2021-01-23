      public static string GetClientOS(string ua, string platform)
        {
            if (ua.Contains("Android"))
                return string.Format("Android {0}", GetMobileVersion(ua, "Android"));
            if (ua.Contains("iPad"))
                return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));
            if (ua.Contains("iPhone"))
                return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));
            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                return "Kindle Fire";
            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                return "Black Berry";
            if (ua.Contains("Windows Phone"))
                return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));
            if (ua.Contains("Mac OS"))
                return "Mac OS";
            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                return "Windows XP";
            if (ua.Contains("Windows NT 6.0"))
                return "Windows Vista";
            if (ua.Contains("Windows NT 6.1"))
                return "Windows 7";
            if (ua.Contains("Windows NT 6.2"))
                return "Windows 8";
            if (ua.Contains("Windows NT 6.3"))
                return "Windows 8.1";
            if (ua.Contains("Windows NT 10"))
                return "Windows 10";
            return  platform + (ua.Contains("Mobile") ? " Mobile " : "");
        }
        public static string GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;
            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;
                if (int.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }
                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }
                if (validCharacter == false)
                    break;
            }
            return version;
        }
