	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Text;
	using System.Web;
    public class FormUrlEncodedContentNoLimit : ByteArrayContent
    {
        public FormUrlEncodedContentNoLimit(IEnumerable<KeyValuePair<string, string>> kvps)
            : base(EncodeContent(kvps))
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        }
        static byte[] EncodeContent(IEnumerable<KeyValuePair<string, string>> kvps)
        {
            if (kvps == null) throw new ArgumentNullException(nameof(kvps));         
            var bytes = new List<byte>();
            foreach (var item in kvps)
            {
                if (bytes.Count != 0) bytes.Add((byte) '&');
                var value = SerializeValue(item.Key);
                if (value != null) bytes.AddRange(value);
                bytes.Add((byte) '=');
                value = SerializeValue(item.Value);
                if (value != null) bytes.AddRange(value);
            }
            return bytes.ToArray();
        }
        static byte[] SerializeValue(string value)
        {
            if (value == null) return null;
            value = HttpUtility.UrlEncode(value)
                .Replace("!", "%21")
                .Replace("(", "%28")
                .Replace(")", "%29")
                .Replace("*", "%2A")
                .Replace("%7E", "~"); // undo escape
            return Encoding.ASCII.GetBytes(value);
        }
    }
