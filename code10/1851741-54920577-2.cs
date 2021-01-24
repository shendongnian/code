    public static string UrlEncode(this string input)
    {
        string output = null;
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (!(Convert.ToString(input[i]) == " " && Convert.ToString(input[i + 1]) == " "))
            {
                output += input[i];
            }
        }
        output += input[input.Length - 1]; // Append last character
        output = output.Replace(" ", "%20");
        return output;
    }
