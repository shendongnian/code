    int Indent = 2;
            
    string[] sarray = new string[6];  //assuming max of 6 levels of indent, 0 based
    for (int iter = 0; iter < 6; iter++)
    {
        //using c0rd's stringbuilder concept, insert ABC as the indent characters to demonstrate any string can be used
        sarray[iter] = new StringBuilder().Insert(0, "ABC", iter).ToString();
    }
    Console.WriteLine(sarray[Indent] +"blah");  //now pretend to output some indented line
