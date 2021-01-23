    string x ="Hi ,World";
    string y = x;
    char[] whitespace = new char[]{ ' ',\t'};          
    string[] fooArray = y.Split(whitespace);  // now you have an array of 3 strings
    y = String.Join(" ", fooArray);
    string[] target = { "Hi", "World", "VW_Slep" };
           
    for (int i = 0; i < target.Length; i++)
    {
        string v = target[i];
        string results = Array.Find(fooArray, element => element.StartsWith(v, StringComparison.Ordinal));
        //
        if (results != null)
        { MessageBox.Show(results); }
                
    }
