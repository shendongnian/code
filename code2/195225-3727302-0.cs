    public string CreateStringFromArray(string[] allLines)
    {        
    StringBuilder builder = new StringBuilder();
            foreach (string item in allLines)
            {
                 builder.Append(item);
            }
            return builder.ToString();  
    }
