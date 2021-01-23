    Console.WriteLine(string.Format("{0} CONTAINS {1} = {2}", str, test1, str.ToLower().Contains(test1.ToLower())));
    
    Console.WriteLine(string.Format("{0} CONTAINS {1} = {2}", str, test2, 
    str.ToLower().Contains(test2.ToLower())));
    
    //Output
    The quick brown fox blah CONTAINS quick = True
    The quick brown fox blah CONTAINS Quick = True
       
