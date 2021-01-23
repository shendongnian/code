                var l = new List<Product> ();
                l.Add (new Product ()
                {
                    Name = "Omnia 7",
                    Category = "Smartphone"
                });
    
                l.Add (new Product ()
                {
                    Name = "Mercedes",
                    Category = "Car"
                });
    
                l.Add (new Product ()
                {
                    Name = "HTC",
                    Category = "Smartphone"
                });
    
                l.Add (new Product ()
                {
                    Name = "AMD",
                    Category = "CPU"
                });
    
                l.Sort (new SmartphonesFirst ());
    
                foreach( var p in l )
                {
                    Console.WriteLine (String.Format ("{0} : {1}", p.Category, p.Name));
                }
