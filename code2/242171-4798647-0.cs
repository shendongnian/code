            string a = "string comparison\r\n";
            string b = "string comparison";
            string c = a.Trim();
            string d = b.Trim();
            if (c == d)
                Console.WriteLine("strings are equal");
            else
                Console.WriteLine("strings are not equal");
            string e = a.Replace("\r\n", "");
            string f = b.Replace("\r\n", "");
            if (e == f)
                Console.WriteLine("strings are equal");
            else
                Console.WriteLine("strings are not equal");
