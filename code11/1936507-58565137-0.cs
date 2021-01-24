List<string> prods = new List<string>();
            prods.AddRange(new List<string>() {
                "Apple",
                "Apricot",
                "Banana",
                "Blueberry",
                "Fig",
                "Grape"
            });
            //Considering that the list is already sorted alphabetically
            //or you can use prods.Sort();
            List<string> newList = new List<string>();
            string alphabets = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            foreach(string a in alphabets.Split(','))
            {
                newList.Add(a);
                foreach (var item in prods)
                {
                    if (item.StartsWith(a) || item.StartsWith(a.ToUpper()))
                    {
                        Console.WriteLine($"adding {item} to  newlist");
                        newList.Add(item);
                    }
                }
            }
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
Please let me know how it works out for you.            
