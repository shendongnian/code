    static string convertToCamelCase(string inputText)
    {
        string result = string.Empty;
        if (string.IsNullOrEmpty(inputText)) return result;
 
        var inputs = inputText.Split('.');
        for(int i = 0; i < inputs.Length; i++)
        {
            if (String.IsNullOrEmpty(inputs[i])) continue;
            inputs[i] = inputs[i].Substring(0, 1).ToLower() + inputs[i].Substring(1);
        }
        result = string.Join(".", inputs);
        return result;
    }
