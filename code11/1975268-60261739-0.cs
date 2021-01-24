        static void Main(string[] args)
        {
            var inputText = "profile.Business.AddressLine1"; 
            
            var result = string.Empty;
            if (inputText.Contains('.'))
            {
                var inputs = inputText.Split('.');
                for (int i = 0; i < inputs.Length; i++)
                {
                    inputs[i] = convertToCamelCase(inputs[i]);
                }
                result = string.Join(".",inputs);
            }
            else
            {
                result = convertToCamelCase(inputText);
            }
        }
        static string convertToCamelCase(string inputText)
        {
            return inputText.Substring(0, 1).ToLower() + inputText.Substring(1);
        }
