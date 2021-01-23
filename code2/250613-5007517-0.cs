    foreach (var con in cons)
    {
        if (con.Name == "NamespaceTable") 
        {
            foreach (var nsElement in con.Elements()) 
            {
                var nsId = nsElement.Value;
                Console.WriteLine(nsId);
            }
        }
        else
        {
            var id = con.Value;
            Console.WriteLine(id);
        }
    }
