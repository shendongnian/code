 csharp
static void Main(string[] args)
        {
            string inputFile = args[0];
            string inputPlane = args[1];
            string inputTime = args[2];
            // Check for output flag "-o"
            bool checkForOutput = Array.Exists(args, element => element == "-o");
            if(!File.Exists(inputFile))
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            var inputFileLines = GetInputFileFormatted(inputFile);
            var splitWords = GetSplitWords(inputFileLines);
            var planeFileLines = GetPlaneFileFormatted(inputPlane);
            var stationDetails = GetStationDetails(inputFileLines.Count, splitWords);
            if (checkForOutput == true)
            {
                //================== Store station names ==================
                string[] names = new string[listLength];
                int nameCounter = 0;
                while (nameCounter < listLength)
                {
                    for (int i = 0; i < splitWords.Length; i += 3)
                    {
                        names[nameCounter] = (splitWords[i]);
                        nameCounter++;
                    }
                }
                //================== Store plane details ==================
                Plane plane1 = new Plane(intPlaneSpec[0], intPlaneSpec[1], intPlaneSpec[2], intPlaneSpec[3], intPlaneSpec[4]);
                //================== Store distance totals between position [i] & [i + 1] ==================
                double[] distanceTotal = new double[listLength];
                for (int i = 0; i < stationDetails.Length - 1; i++)
                {
                    distanceTotal[i] = Math.Round(Station.Distance((stationDetails[i].XValue),
                    (stationDetails[i + 1].XValue),
                    (stationDetails[i].YValue),
                    (stationDetails[i + 1].YValue)), 4);
                }
                int lastStation = stationDetails.GetUpperBound(0);
                // Store last distance total
                distanceTotal[lastStation] = Math.Round(Station.Distance((stationDetails[lastStation].XValue),
                (stationDetails[0].XValue),
                (stationDetails[lastStation].YValue),
                (stationDetails[0].YValue)), 4);
                //================== Setup list for storing times ==================
                DateTime startTime = DateTime.Parse(inputTime);
                List<DateTime> temporaryTimes = new List<DateTime>();
                temporaryTimes.Add(startTime); // Add initial value "23:00
                List<string> timeStrings = new List<string>();
                for (int i = 0; i < distanceTotal.Length; i++)
                {
                    temporaryTimes.Add(startTime.AddMinutes((Tour.CalTime(distanceTotal[i], plane1))));
                    string stringVersion = startTime.ToString(@"hh\:mm");
                    timeStrings.Add(stringVersion);
                    startTime = (startTime.AddMinutes((Tour.CalTime(distanceTotal[i], plane1))));
                }
                //================== Store total duration of trip ==================
                int last = (temporaryTimes.Count);
                TimeSpan totalTime = temporaryTimes[last - 1] - temporaryTimes[0];
                //================== Setup list for storing tour names ==================
                List<string> tourNames = new List<string>();
                //================== Output to Console Window & file ==================
                // Setup output file
                string outputFile = args[4];
                FileStream outFile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                Console.WriteLine("Reading input from {0}", inputFile);
                if (totalTime.Days >= 1)
                {
                    Console.WriteLine("Tour time: {0} days {1} hours {2} minutes", totalTime.Days, totalTime.Hours, totalTime.Minutes);
                }
                else
                {
                    Console.WriteLine("Tour time: {0} hours {1} minutes", totalTime.Hours, totalTime.Minutes);
                }
                Console.WriteLine("Optimising tour length: Level 1...");
                Console.WriteLine("Tour length: {0}", distanceTotal.Sum()); // sum of trip
                writer.WriteLine(distanceTotal.Sum()); // write sum to output file
                for (int i = 0; i < stationDetails.Length - 1; i++)
                {
                    Console.WriteLine("{0}\t->\t{1}\t{2}",
                    stationDetails[i].StationName.Substring(0, 2),
                    stationDetails[i + 1].StationName.Substring(0, 2),
                    distanceTotal[i]);
                    // Store names to tour names
                    tourNames.Add(stationDetails[i].StationName.Substring(0, 2));
                    tourNames.Add(stationDetails[i + 1].StationName.Substring(0, 2));
                    writer.WriteLine("{0}\t->\t{1}\t{2}",
                    stationDetails[i].StationName.Substring(0, 2),
                    stationDetails[i + 1].StationName.Substring(0, 2),
                    Math.Round(Station.Distance((stationDetails[i].XValue),
                    (stationDetails[i + 1].XValue),
                    (stationDetails[i].YValue),
                    (stationDetails[i + 1].YValue)), 4));
                }
                // Write Last distance to console
                Console.WriteLine("{0}\t->\t{1}\t{2}",
                stationDetails[lastStation].StationName.Substring(0, 2),
                stationDetails[0].StationName.Substring(0, 2), distanceTotal[lastStation]);
                //================== Store tour Details in object ==================
                Tour tour1 = new Tour(4.2, plane1, tourNames, temporaryTimes, totalTime);
                ////================== Algorithm ==================
                //// Empty tour with post office initially added
                List<Station> stationsLeft = stationDetails.ToList();
                List<Station> fuckingDone = Tour.SimpleHueristic(stationsLeft);
                foreach (Station var in fuckingDone)
                {
                    Console.WriteLine("{0} {1} {2}", var.StationName, var.XValue, var.YValue);
                }
                // Write last distance to output file
                writer.WriteLine("{0}\t->\t{1}\t{2}",
                stationDetails[lastStation].StationName.Substring(0, 2),
                stationDetails[0].StationName.Substring(0, 2),
                Math.Round(Station.Distance((stationDetails[lastStation].XValue),
                (stationDetails[0].XValue),
                (stationDetails[lastStation].YValue),
                (stationDetails[0].YValue)), 4));
                // Close output file
                writer.Close();
                outFile.Close();
            }
            //================== END OF IF STATEMENT - NEXT SECTION OF CODE (NEEDS TO BE THE SAME) ================
            else if (checkForOutput == false)
            {
                //================== Store plane details ==================
                Plane plane1 = new Plane(intPlaneSpec[0], intPlaneSpec[1], intPlaneSpec[2], intPlaneSpec[3], intPlaneSpec[4]);
                //================== Store time details ==================
                DateTime newTime = DateTime.Parse(inputTime);
                string formatedTime = newTime.ToString("HH:mm");
                //================== Store distance totals between position [i] & [i + 1] ==================
                double[] distanceTotal = new double[listLength];
                for (int i = 0; i < stationDetails.Length - 1; i++)
                {
                    distanceTotal[i] = Math.Round(Station.Distance((stationDetails[i].XValue),
                    (stationDetails[i + 1].XValue),
                    (stationDetails[i].YValue),
                    (stationDetails[i + 1].YValue)), 4);
                }
                int lastStation = stationDetails.GetUpperBound(0);
                // Store last distance total
                distanceTotal[lastStation] = Math.Round(Station.Distance((stationDetails[lastStation].XValue),
                (stationDetails[0].XValue),
                (stationDetails[lastStation].YValue),
                (stationDetails[0].YValue)), 4);
                //================== Setup list for storing times ==================
                List<DateTime> temporaryTimes = new List<DateTime>();
                //================== Setup list for storing tour names ==================
                List<string> tourNames = new List<string>();
                //================== Output to only Console ==================
                Console.WriteLine("Reading input from {0}", inputFile);
                Console.WriteLine("Optimising tour length: Level 1...");
                Console.WriteLine("Tour length: {0}", distanceTotal.Sum()); // sum of trip
                for (int i = 0; i < stationDetails.Length - 1; i++)
                {
                    Console.WriteLine("{0}\t->\t{1}\t{2}",
                    stationDetails[i].StationName.Substring(0, 2),
                    stationDetails[i + 1].StationName.Substring(0, 2),
                    distanceTotal[i]);
                }
                // Output last distance back to post office
                Console.WriteLine("{0}\t->\t{1}\t{2}",
                stationDetails[lastStation].StationName.Substring(0, 2),
                stationDetails[0].StationName.Substring(0, 2), distanceTotal[lastStation]);
            }
            else
            {
                //========== Display error message if input is incorrect ============
                Console.WriteLine("Invalid Input");
            }
            Console.ReadLine();            
        }
        static List<string> GetInputFileFormatted(string inputFile)
        {
            List<string> lines = File.ReadAllLines(inputFile).ToList(); // Read text and put into list
            return lines;
        }
        static string[] GetSplitWords(List<string> inputFileLines)
        {
            string words = inputFileLines.Aggregate((i, j) => i + " " + j).ToString(); // Split into sentences
            return words.Split(); // Each individual word
        }
        static List<string> GetPlaneFileFormatted(string inputPlane)
        {
            List<string> planeLines = File.ReadAllLines(inputPlane).ToList(); // Read text and put into list
            string planeElements = planeLines.Aggregate((i, j) => i + " " + j).ToString();
            string[] stringPlaneSpec = planeElements.Split();
            int[] intPlaneSpec = new int[stringPlaneSpec.Length];
            for (int n = 0; n < stringPlaneSpec.Length; n++)
                intPlaneSpec[n] = int.Parse(stringPlaneSpec[n]);
            return planeLines;
        }
        static Station[] GetStationDetails(int inputFileLinesLength, string[] splitWords)
        {
            Station[] stationDetails = new Station[inputFileLinesLength];
            int stationCounter = 0;
            while (stationCounter < inputFileLinesLength)
            {
                for (int i = 0; i < splitWords.Length; i += 3)
                {
                    stationDetails[stationCounter] = new Station(splitWords[i], Convert.ToInt32(splitWords[i + 1]), Convert.ToInt32(splitWords[i + 2]));
                    stationCounter++;
                }
            }
            return stationDetails;
        }
