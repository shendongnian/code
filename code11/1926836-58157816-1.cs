    public static class SharingUtility
    {
        public static string UrlEncode(string value)
        {
            var base64Value = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
            return "u!" + base64Value.TrimEnd('=').Replace('/','_').Replace('+','-');
        }
        
        public static string UrlDecode(string encodedValue)
        {
            var safeEncodedValue = encodedValue.Replace('_','/').Replace('-','+').Substring(2) + "==";
            var bytes = System.Convert.FromBase64String(safeEncodedValue);
            var value = System.Text.Encoding.UTF8.GetString(bytes);
            return value;
        }
    }
