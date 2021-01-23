    namespace WebProject.Core.Utilities
        {
            public static class UserInputSanitizer
            {
                
                public static string CapitalizeFirstLetterTrim(string input)
                {
                    // Trim
                    input.Trim();
                    // Make First letter UpperCase and the rest levae lower case
                    return input.Substring(0, 1).ToUpper() + input.Substring(1);
                    
                }
    
            }
        }
