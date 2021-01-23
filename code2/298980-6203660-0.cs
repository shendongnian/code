            var json = new JavaScriptSerializer();
            var s1 = new Size(5, 125);
            var serialized = s1.ToString().Replace("=",":"); 
            Console.WriteLine(serialized);
            var s2 = json.Deserialize<Size>(serialized);
            Console.WriteLine(s2);
