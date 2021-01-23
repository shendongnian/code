            string msg = "The boy said to his mother, \"Can I have some candy?\"";
            System.IO.MemoryStream s = new System.IO.MemoryStream(Encoding.Unicode.GetBytes(msg));
            TextFieldParser p = new TextFieldParser(s, Encoding.Unicode);
            p.Delimiters = new string[] { " ", "," };
            foreach(var f in p.ReadFields().Where(f => f != ""))
                Console.WriteLine(f);
