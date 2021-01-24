        static void Main(string[] args)
        {
            string inputText = "profile.Business.AddressLine1"; 
            convertToCamelCase(inputText); //profile.business.addressLine1
        }
        static string convertToCamelCase(string inputText)
        {
            string result = string.Empty;
            if (inputText.Contains('.'))
            {
                var inputs = inputText.Split('.');
                for (int i = 0; i < inputs.Length; i++)
                {
                    inputs[i] = inputs[i].Substring(0, 1).ToLower() + inputs[i].Substring(1);
                }
                result = string.Join(".", inputs);
            }
            else
            {
                result = convertToCamelCase(inputText);
            }
            return result;
        }
