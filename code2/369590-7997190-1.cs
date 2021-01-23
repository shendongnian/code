    //Create a new variable of string
    var x = string.Empty;
    //Open a new FileStream
    using (var fs = new FileStream(path,...))
    //Open the StreamReader
    using (var sr = new StreamReader(fs))
    {
    //Read out the whole CSV
       x = sr.ReadToEnd();
    }
    
    //Split up the string by ',' and whitespaces. dismiss empty entries
    var stringArray = x.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    //stolen code following 
    var myEnumerable = stringArray.Skip(2)
                                  .Where((item, index) => index % 4 == 3 || index % 4 == 0)
                                  .Skip(1);
