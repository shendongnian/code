    for(i = 0;i < yourList.Count; i++)
    {
       String str = yourList[i];
       if(str.Contains("Animal")
       {
           var parts = string.Split(@',');
           parts[2] = Integer.Parse(parts[2]) + 1;
           str = String.Join(parts, ",");
       }
    }
