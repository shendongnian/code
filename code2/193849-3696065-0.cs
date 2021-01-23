    DropDownList1.DataSource = myBooks.OrderBy(n => ReplaceNoise(n.Title))
    public string ReplaceNoise(string input)
    {
         string[] noise = new string[] { "the", "an", "a" };
         //surely this could be LINQ'd 
         foreach (string n in noise)
         {
             if (input.ToLower().StartsWith(n))
             {
                 return input.Substring(n.Length).Trim();
             }
         }
         return input;
    }
 
