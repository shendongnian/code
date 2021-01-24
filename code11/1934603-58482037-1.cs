            string seq3 = "Zeile1: 5,4,2; Zeile2: 9,4,8; Zeile3: 5,3,6";
            string seq4 = "Zeile1: 2,5,4,2; Zeile2: 4,1,7,8; Zeile3: 5,3,6,1; Zeile4: 9,2,3,5";
            string seq5 = "Zeile1: 2,7,5,4,2; Zeile2: 9,4,1,7,8; Zeile3: 5,3,6,7,1; Zeile4: 9,2,3,5,0; Zeile5: 7,2,5,1,6";
            var resultArray = seq5.Split(';').Select(s => s.Split(':')[1].Trim().Split(',').Select(n => int.Parse(n)).ToArray()).ToArray();
            foreach (var subArray in resultArray)
            {
                foreach (var number in subArray)
                {
                    Console.Write(number);
                }
                Console.WriteLine($" (line average: {subArray.Average()})");
            }
            Console.ReadKey();
