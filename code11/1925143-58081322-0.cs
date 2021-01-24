            var chems = new Dictionary<int, string>();
            chems.Add(221, "Hydrogen");
            chems.Add(431,"Sulphur");
            chems.Add(332, "Ammonia");
            chems.Add(688, "Nitrogen");
         
            var order = chems.Keys.ToList();
            order.Sort();
            foreach (var chem in order)
            {
                
                Console.WriteLine("{0}:{1}",chem,chems[chem]);
            }
            Console.ReadLine();
            var order = chems.Keys.ToList();
            order.Sort();
            foreach (var chem in order)
            {
                
                Console.WriteLine("{0}:{1}",chem,chems[chem]);
            }
            Console.ReadLine();
