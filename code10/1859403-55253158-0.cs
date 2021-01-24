      static void Main(string[] args)
        {
            var res = 0;
            var r = new Regex(@"\d");// you can try "\d+" and you will see the difference
            var matches = r.Matches("feawfwe312faewfa4gaeg1feaga67awfaw2");
            if (matches != null && matches.Count > 0)
            {
                foreach (var m in matches)
                    res += int.Parse(m.ToString());
            }
            Console.WriteLine(res);
            Console.ReadKey();
        }
