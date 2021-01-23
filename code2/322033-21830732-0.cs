        static HttpStatusCode? GetStatusCode(string response)
        {
            string rawCode = response.Split(' ').Skip(1).FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(rawCode) && rawCode.Length > 2)
            {
                rawCode = rawCode.Substring(0, 3);
                int code;
                if (int.TryParse(rawCode, out code))
                {
                    return (HttpStatusCode)code;
                }
            }
            return null;
        }
 
