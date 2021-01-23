         class Person
            {
             string UserName {get;set;}
             string LanguageSpoken {get; set;}    
            }
        
        List<Person> table = new List<Person>()
        { new Person(){UserName="Bob"; LanguageSpoken = "English"}
        /* next persons*/
        };
    var userNameGroups = from n in table
            group n by n.UserName into g
            select new { keyUserName = g.Key, LanguageSpoken = g };
    
        foreach (var g in numberGroups)
        {
            Console.Write(g.keyUserName.ToString());
            foreach (var n in g.LanguageSpoken)
            {
                Console.WriteLine(n.ToString());
            }
        }
