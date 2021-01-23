        public string HtmlDecodeText(string value, int decodingCount = 0)
        {
            // If decoded text equals the original text, then we know decoding is done;
            // Don't go past 4 levels of decoding to prevent possible stack overflow,
            // and because we don't have a valid use case for that level of multi-decoding.
            if (decodingCount < 0)
            {
                decodingCount = 1;
            }
            if (decodingCount >= 4)
            {
                return value;
            }
            var decodedText = WebUtility.HtmlDecode(value);
            if (decodedText.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return value;
            }
            return HtmlDecodeText(decodedText, ++decodingCount);
        }
