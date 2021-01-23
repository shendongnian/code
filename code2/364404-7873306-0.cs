            public class SmartphonesFirst : IComparer<Product>
            {
                const string Smartphone = "Smartphone";
    
                public int Compare( Product x, Product y )
                {
                    if( x.Category == Smartphone && y.Category != Smartphone )
                    {
                        return -1;
                    }
                    if( y.Category == Smartphone && x.Category != Smartphone )
                    {
                        return 1;
                    }
                    else
                    {
                        return Comparer<String>.Default.Compare (x.Category, y.Category);
                    }
                }
            }
    
