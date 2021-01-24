    public class ValidationService
    {
        private const int MaximumStringLength = 11;
        public bool IsStringValid(string text)
        {
            return IsStringLengthCorrect(text) && IsStringUpper(text);
        }
        public bool IsStringLengthCorrect(string text)
        {
            return text.Length < MaximumStringLength;
        }
        public bool IsStringUpper(string text)
        {
            return text.All(x => char.IsUpper(x));
        }
        public string ValidateStringLength(string text)
        {
            if (IsStringLengthCorrect(text))
            {
                return text;
            }
            else
            {
                return text.Substring(0, MaximumStringLength);
            }
        }
        public string ValidateStringUpper(string text)
        {
            if (IsStringUpper(text))
            {
                return text;
            }
            else
            {
                return text.ToUpper();
            }
        }
    }
