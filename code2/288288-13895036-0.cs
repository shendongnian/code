    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace s3_polocySigning
    {
        public static class Encode
        {
         //   static string thanks = "http://stackoverflow.com/questions/6999648/signing-post-form-in-c-sharp-for-uploading-to-amazon-s3";
            public static string BuildURL(string AccessKey, string SecretKey, DateTime timeToExpire, string BucketName, string FileKey)
            {
                System.Security.Cryptography.HMAC hmacProvider = System.Security.Cryptography.HMAC.Create();
                string returnString = string.Empty;
                hmacProvider.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(SecretKey);
                string expirationString = ConvertToUnixTimestamp(timeToExpire).ToString();
                //System.Uri.UriSchemeHttp &/ System.Web.HttpUtility.UrlEncode
                string assembledRequest = "GET" + "\n" + "\n" + "\n" + expirationString + "\n" + "/" + BucketName + "/" + UrlEncode(FileKey);
                byte[] hashedSignature = hmacProvider.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(assembledRequest));
    
                returnString = Convert.ToBase64String(hashedSignature);
                return "https://" + "s3.amazonaws.com/" + BucketName + "/" + FileKey + "?AWSAccessKeyId=" + AccessKey + "&Expires=" + expirationString + "&Signature=" + UrlEncode(returnString);
            }
            private static double ConvertToUnixTimestamp(DateTime ExpDate)
            {
                if (DateTime.MinValue == ExpDate)
                    return  2133721337;
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                TimeSpan diff = ExpDate - origin;
                return Convert.ToDouble(Math.Floor(diff.TotalSeconds));
            }
      
     
    
     
    
            
            public static string GetSig(string policyStr, string secretKey)
            {
                policyStr = GetBase64_string(policyStr);
                var signature = new System.Security.Cryptography.HMACSHA1(GetBase64(secretKey));
                var bytes = GetBase64(policyStr);
                var moreBytes = signature.ComputeHash(bytes);
                var encodedCanonical = Convert.ToBase64String(moreBytes);
                return encodedCanonical;
            }
            public static string GetBase64_string(string policyStr)
            {
                policyStr = policyStr.Replace("/r", "").Replace("/n", "").Replace(System.Environment.NewLine, "\n");
                return Convert.ToBase64String(Encoding.ASCII.GetBytes(policyStr));
            }
            public static byte[] GetBase64(string policyStr)
            {
                return Encoding.ASCII.GetBytes(policyStr);
            }
    
    
    
    
           // ThanksTo = "http://www.west-wind.com/weblog/posts/2009/Feb/05/Html-and-Uri-String-Encoding-without-SystemWeb";
            // avoid useing System.Web.HttpUtility.UrlEncode
    
            /// <summary>
            /// UrlEncodes a string without the requirement for System.Web
            /// </summary>
            /// <param name="String"></param>
            /// <returns></returns>
            // [Obsolete("Use System.Uri.EscapeDataString instead")]
            public static string UrlEncode(string text)
            {
                // Sytem.Uri provides reliable parsing
                return System.Uri.EscapeDataString(text);
            }
    
            /// <summary>
            /// UrlDecodes a string without requiring System.Web
            /// </summary>
            /// <param name="text">String to decode.</param>
            /// <returns>decoded string</returns>
            public static string UrlDecode(string text)
            {
                // pre-process for + sign space formatting since System.Uri doesn't handle it
                // plus literals are encoded as %2b normally so this should be safe
                text = text.Replace("+", " ");
                return System.Uri.UnescapeDataString(text);
            }
    
            /// <summary>
            /// Retrieves a value by key from a UrlEncoded string.
            /// </summary>
            /// <param name="urlEncoded">UrlEncoded String</param>
            /// <param name="key">Key to retrieve value for</param>
            /// <returns>returns the value or "" if the key is not found or the value is blank</returns>
            public static string GetUrlEncodedKey(string urlEncoded, string key)
            {
                urlEncoded = "&" + urlEncoded + "&";
    
                int Index = urlEncoded.IndexOf("&" + key + "=", StringComparison.OrdinalIgnoreCase);
                if (Index < 0)
                    return "";
    
                int lnStart = Index + 2 + key.Length;
    
                int Index2 = urlEncoded.IndexOf("&", lnStart);
                if (Index2 < 0)
                    return "";
    
                return UrlDecode(urlEncoded.Substring(lnStart, Index2 - lnStart));
            }
        }
    }
