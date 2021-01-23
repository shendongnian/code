    string testString = "";
    Console.WriteLine(string.Format("IsNullOrEmpty : {0}", string.IsNullOrEmpty(testString)));
    Console.WriteLine(string.Format("IsNullOrWhiteSpace : {0}", string.IsNullOrWhiteSpace(testString)));
    Console.ReadKey();
    
    Result :
    IsNullOrEmpty : True
    IsNullOrWhiteSpace : True
    
    **************************************************************
    string testString = " MDS   ";
    
    IsNullOrEmpty : False
    IsNullOrWhiteSpace : False
    
    **************************************************************
    string testString = "   ";
    
    IsNullOrEmpty : False
    IsNullOrWhiteSpace : True
    
    **************************************************************
    string testString = string.Empty;
    
    IsNullOrEmpty : True
    IsNullOrWhiteSpace : True
    
    **************************************************************
    string testString = null;
    
    IsNullOrEmpty : True
    IsNullOrWhiteSpace : True
