    string payloadPropertyName = "\"Payload\":\"";
            int startIndex = rawMessage.IndexOf(payloadPropertyName, StringComparison.Ordinal) + payloadPropertyName.Length;
            int endIndex = rawMessage.IndexOf("\",\"SubmittingBy\"", StringComparison.Ordinal);
            string payload = rawMessage.Substring(startIndex, endIndex - startIndex);
            payload = payload.Replace("\\\"", "\"");
            return Newtonsoft.Json.Linq.JToken.Parse(payload).ToString(Newtonsoft.Json.Formatting.Indented);
