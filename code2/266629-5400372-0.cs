    DirectorySearcher searcher = new DirectorySearcher();
    
    searcher.SearchRoot = baseDirectory;
    searcher.Filter = "(objectCategory=organizationalUnit)";
    searcher.SearchScope = SearchScope.Subtree;
    
    var ouResults = searcher.FindAll();
    
    foreach (SearchResult ou in ouResults)
    {
    
        ResultPropertyCollection myResultPropColl;
        myResultPropColl = ou.Properties;
        Console.WriteLine("The properties of the " +
                "'mySearchResult' are :");
    
        foreach (string myKey in myResultPropColl.PropertyNames)
        {
            string tab = "    ";
            Console.WriteLine(myKey + " = ");
            foreach (Object myCollection in myResultPropColl[myKey])
            {
                Console.WriteLine(tab + myCollection);
            }
        }
    }
