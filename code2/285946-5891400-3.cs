    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < indecies.Length; i++)
    {
       sb.Append(result[i]); // make [i-1] if indecies are 1 based.
    }
    string result3 = sb.ToString();
