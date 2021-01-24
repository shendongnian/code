        public static partial class StringsExtensions
        {        
            // Changes example_id to exampleId for mapping
            public static string ToModelName(this string text)
            {
                // First we make a space
                text = text.Replace("_", " ");
                // Capitalize every word
                text = text.ToUpperEveryWord(); // <-- Code Below #4                    
                // remove the extra space
                text = text.Replace(" ", "");
                return text;
            }
        }
