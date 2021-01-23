    public static class CookieSerializer
    {
        /// <summary>
        /// Serializes the cookie collection to the stream.
        /// </summary>
        /// <param name="cookies">You can obtain the collection through your <see cref="CookieAwareWebClient">WebClient</see>'s <code>CookieContainer.GetCookies(Uri)</code>-method.</param>
        /// <param name="address">The <see cref="Uri">Uri</see> that produced the cookies</param>
        /// <param name="stream">The stream to which to serialize</param>
        public static void Serialize(CookieCollection cookies, Uri address, Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                for (var enumerator = cookies.GetEnumerator(); enumerator.MoveNext();)
                {
                    var cookie = enumerator.Current as Cookie;
                    if (cookie == null) continue;
                    writer.WriteLine(address.AbsoluteUri);
                    writer.WriteLine(cookie.Comment);
                    writer.WriteLine(cookie.CommentUri == null ? null : cookie.CommentUri.AbsoluteUri);
                    writer.WriteLine(cookie.Discard);
                    writer.WriteLine(cookie.Domain);
                    writer.WriteLine(cookie.Expired);
                    writer.WriteLine(cookie.Expires);
                    writer.WriteLine(cookie.HttpOnly);
                    writer.WriteLine(cookie.Name);
                    writer.WriteLine(cookie.Path);
                    writer.WriteLine(cookie.Port);
                    writer.WriteLine(cookie.Secure);
                    writer.WriteLine(cookie.Value);
                    writer.WriteLine(cookie.Version);
                }
            }
        }
        /// <summary>
        /// Deserializes <see cref="Cookie">Cookie</see>s from the <see cref="Stream">Stream</see>, 
        /// filling the <see cref="CookieContainer">CookieContainer</see>.
        /// </summary>
        /// <param name="stream">Stream to read</param>
        /// <param name="container">Container to fill</param>
        public static void Deserialize(Stream stream, CookieContainer container)
        {
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var uri = Read(reader, absoluteUri => new Uri(absoluteUri, UriKind.Absolute));
                    var cookie = new Cookie();
                    cookie.Comment = Read(reader, comment => comment);
                    cookie.CommentUri = Read(reader, absoluteUri => new Uri(absoluteUri, UriKind.Absolute));
                    cookie.Discard = Read(reader, bool.Parse);
                    cookie.Domain = Read(reader, domain => domain);
                    cookie.Expired = Read(reader, bool.Parse);
                    cookie.Expires = Read(reader, DateTime.Parse);
                    cookie.HttpOnly = Read(reader, bool.Parse);
                    cookie.Name = Read(reader, name => name);
                    cookie.Path = Read(reader, path => path);
                    cookie.Port = Read(reader, port => port);
                    cookie.Secure = Read(reader, bool.Parse);
                    cookie.Value = Read(reader, value => value);
                    cookie.Version = Read(reader, int.Parse);
                    container.Add(uri, cookie);
                }
            }
        }
        /// <summary>
        /// Reads a value (line) from the serialized file, translating the string value into a specific type
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="reader">Input stream</param>
        /// <param name="translator">Translation function - translate the read value into 
        /// <typeparamref name="T"/> if the read value is not <code>null</code>.
        /// <remarks>If the target type is <see cref="Uri">Uri</see> , the value is considered <code>null</code> if it's an empty string.</remarks> </param>
        /// <param name="defaultValue">The default value to return if the read value is <code>null</code>.
        /// <remarks>The translation function will not be called for null values.</remarks></param>
        /// <returns></returns>
        private static T Read<T>(TextReader reader, Func<string, T> translator, T defaultValue = default(T))
        {
            var value = reader.ReadLine();
            if (value == null)
                return defaultValue;
            if (typeof(T) == typeof(Uri) && String.IsNullOrEmpty(value))
                return defaultValue;
            return translator(value);
        }
    }
