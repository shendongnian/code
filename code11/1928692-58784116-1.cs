            if (arrayLines.Length > 2)
            {
                var arrayColsPositions = new List<int>();
                // Find cols positions
                arrayColsPositions.Add(0);
                var firstDataLine = arrayLines[2];
                var columnsPositionDetector = new Regex(@" {2,}", RegexOptions.Singleline);
                foreach (Match match in columnsPositionDetector.Matches(firstDataLine))
                {
                    arrayColsPositions.Add(match.Index + match.Length);
                }
                // Find headers
                arrayHeaders = ReadLineValues(arrayLines[0], arrayColsPositions).ToList();
                // Find data lines
                for (int lineId = 2; lineId < arrayLines.Length; lineId++)
                {
                    arrayData.Add(ReadLineValues(arrayLines[lineId], arrayColsPositions).ToList());
                }
                Console.WriteLine("\n*** Array headers :");
                Console.WriteLine(string.Join(", ", arrayHeaders));
                Console.WriteLine("\n*** Array lines data :");
                foreach (var record in arrayData)
                {
                    Console.WriteLine(string.Join(", ", record));
                }
            }
            else
                Console.WriteLine("The array is empty.");
