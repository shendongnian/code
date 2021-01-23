            const string test = "STK_PD_BEZ|%s|STK_ID|%s|STK_EBENE|0|ID|%s\r\nSTK_ID|%s|ORDERPOS|%s|STK_EBENE|1|STK_PD_BEZ|%s|STK_FLAENGE|%.2f|STK_FBREITE|%.2f|STK_FDICKE|%.2f|ID|%s|PARENTID|%s\r\n,POSNR,ORDERID,POSNR_NR_ID,ORDERID,POSSTR,CP90NAME,WIDTH,DEPTH,HEIGHT,ARTNR_NR_ID,POSNR_NR_ID";
            // [0] - format string
            // [1..n] - arguments for format
            string[] args = test.Split(',');
            // Source parts
            string[] parts = args[0].Split("|\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            
            // Format - arg pair
            var parsed = new List<Tuple<string, string>>();
            // Current format string
            var format = new List<string>();
            
            // Start from 1 since we skip format string
            int currentValue = 1;
            // Building
            foreach (var part in parts)
            {
                if (part.StartsWith("%"))
                {
                    format.Add(part);
                    parsed.Add(Tuple.Create(string.Join("|", format), args[currentValue++]));
                    format.Clear();
                }
                else format.Add(part);
            }
            // Printing
            foreach (var pair in parsed)
            {
                Console.WriteLine("{0} = {1}", pair.Item1, pair.Item2);
            }
            Console.ReadLine();
