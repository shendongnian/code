    var csv =
    @"#Books (format: ISBN, Title, Authors, Publisher, Date, Price)
    0735621632,CLR via C#,Jeffrey Richter,Microsoft Press,02-22-2006,59.99
    0321127420,Patterns Of Enterprise Application Architecture,Martin Fowler,Addison-Wesley, 11-05-2002,54.99
    0321200683,Enterprise Integration Patterns,Gregor Hohpe,Addison-Wesley,10-10-2003,54.99
    0321125215,Domain-Driven Design,Eric Evans,Addison-Wesley Professional,08-22-2003,54.99
    1932394613,Ajax In Action,Dave Crane;Eric Pascarello;Darren James,Manning Publications,10-01-2005,44.95";
    
      using (var reader = new StringReader(csv) /*new StreamReader("books.csv")*/)
      {
      
        var lines = new List<string>();
    	string linebuf;
    	 while ((linebuf = reader.ReadLine()) != null)
    				{
    					lines.Add(linebuf);
    				}
    	var books =
    	  from line in lines
    	  where !line.StartsWith("#")
    	  let parts = line.Split(',')
    	  select new { Isbn=parts[0], Title=parts[1], Publisher=parts[3] };
    
    	//books.Dump();
    
    	var query =
    	from book in books
    	from b in books
    	where book.Isbn == b.Isbn
    	select new 
    	{       
    		book.Isbn,
    		book.Title
    	};
    	query.Dump();
    }
