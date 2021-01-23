            int[] list = { 1, 3, 7, 13,21};
            int v;
            try {
                v=list.Single(n => n > 15);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            int? v2;
            v2 = list.SingleOrDefault(n => n > 30);
            Console.WriteLine(v2.ToString());
            // output: 0
            int v3;
            v3=list.SingleOrDefault(n => n > 30);            
            Console.WriteLine(v3.ToString());
            // output: 0
            string[] slist = {"a", "b", "c"};
            var v4 = slist.SingleOrDefault(s => s == "z");
            Console.WriteLine(v4==null);
            // output: true     <-- i.e. it is a reference type + it is nullable.
