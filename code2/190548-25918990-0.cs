        /// <summary>
        /// Character Encodes a (string).  Specifically used for Querystring parameters.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="String"></param>
        /// <returns>string</returns>
        public static string EncodeForQueryString(this string String)
        {
            String = System.Web.HttpUtility.UrlEncode(String);
            return String;
        }
        /// <summary>
        /// Character Decodes a (string).  Specifically used for Querystring parameters.
        /// </summary>
        /// <remarks>The plus sign causes issues when using System.Web.HttpUtility.UrlDeEncode.  The plus sign is often decoded before it reaches this method.  This method will replace any extra + with %2b before attempting to decode</remarks>
        /// <param name="String"></param>
        /// <returns>string</returns>
        public static string DecodeForQueryString(this string String)
        {
            String = String.Replace("+", "%2b");
            String = System.Web.HttpUtility.UrlDecode(String);
            return String;
        }
