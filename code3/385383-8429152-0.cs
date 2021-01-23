            var babies1 = new List<Baby1>(5);
            for (int i = 0; i < 5; i++)
            {
                babies1.Add(new Baby1 { Name = "Babies1 " + i, Var1 = 1});
            }
            var babies2 = new List<Baby2>(5);
            for (int i = 0; i < 5; i++)
            {
                babies2.Add(new Baby2 { Name = "Babies2 " + i });
            }
            foreach (Baby b in babies1.Union<Baby>(babies2))
            {
                b.Var1 = 50;
            }
            foreach (var baby2 in babies2)
            {
                Console.WriteLine(baby2.Var1);
            }
            foreach (var baby1 in babies1)
            {
                Console.WriteLine(baby1.Var1);
            }
