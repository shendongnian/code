    int p1 = parameters.IndexOf(@">");
    Console.WriteLine("p1 = " + p1);
    
    int p2 = parameters.IndexOf(@"<", parameters.IndexOf(@"<") + 1);
    Console.WriteLine("p2 = " + p2);
    
    Console.ReadKey();
    
    string parametersSub = parameters.Substring(p1, p2 - p1);
    Console.WriteLine("parametersSub: " + parametersSub);
