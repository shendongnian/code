            Console.WriteLine("College File Processor");
            Console.WriteLine("*************************************");
            Console.WriteLine("(H)elp");
            Console.WriteLine("Process (W)orkouts");
            Console.WriteLine("Process (I)nterviews");
            Console.WriteLine("Process (P)ro Days");
            Console.WriteLine("(S)tart Processing");
            Console.WriteLine("E(x)it");
            Console.WriteLine("*************************************");
            string response = "";
            string videotype = "";
            bool starting = false;
            bool exiting = false;
            response = Console.ReadLine();
            while ( response != "" )
            {
                switch ( response  )
                {
                    case "H":
                    case "h":
                        DisplayHelp();
                        break;
                    case "W":
                    case "w":
                        Console.WriteLine("Video Type set to Workout");
                        videotype = "W";
                        break;
                    case "I":
                    case "i":
                        Console.WriteLine("Video Type set to Interview");
                        videotype = "I";
                        break;
                    case "P":
                    case "p":
                        Console.WriteLine("Video Type set to Pro Day");
                        videotype = "P";
                        break;
                    case "S":
                    case "s":
                        if ( videotype == "" )
                        {
                            Console.WriteLine("Please Select Video Type Before Starting");
                        }
                        else
                        {
                            Console.WriteLine("Starting...");
                            starting = true;
                        }
                        break;
                    case "E":
                    case "e":
                        Console.WriteLine("Good Bye!");
                        System.Threading.Thread.Sleep(100);
                        exiting = true;
                        break;
                }
                if ( starting || exiting)
                {
                    break;
                }
                else
                {
                    response = Console.ReadLine();
                }
            }
            if ( starting )
            {
                ProcessFiles();
            }
