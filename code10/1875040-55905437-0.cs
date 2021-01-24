            string[] a1 = new string[] {
                "10; 155.4587; 0.01",
                "20; 255.4587; 0.02",
                "30; 355.4587; 0.03",
            };
            List<string> r1 = new List<string>();
            List<string> r2 = new List<string>();
            List<string> r3 = new List<string>();
            foreach (string t1 in a1)
            {
                string[] t2 = t1.Split(";");
                r1.Add(t2[0]);
                r2.Add(t2[1]);
                r3.Add(t2[2]);
            }
