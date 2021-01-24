    public static string ConvertToPigLatin(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        if (BeginsWithAVowel(input))
        {
            // Add "way" to the end of the string and return it
            return input + "way";
        }
        // Remove the first character and add it, plus "ay", to the end and return it
        return input.Substring(1) + input.Substring(0, 1) + "ay";
    }
