                string[] inputs = {
                    "Corp.Signals.LivingRoom.Temperature@TStart",
                    "int(Corp.Signals.BedRoom.NoiseLevel@T+4)",
                    "Corp.Signals.LivingRoom.Temperature@TMid+2.3",
                    "Corp.Signals.LivingRoom.Temperature",
                    "Corp.Signals.LivingRoom.Temperature@T+",
                    "Corp.Signals.BedRoom.NoiseLevel@T+4)",
                    "int(Corp.Signals.LivingRoom.Temperature@T-.2"
                                  };
                //Function(SignalName@Time) sample, Function and Time optional
                string pattern = @"^((\w[\w.]+(@T(([+-](\d+|\d*.\d+))|\w+))?)|(\w+\(\w[\w.]+(@T(([+-](\d+|\d*.\d+))|\w+))?\)))$";
                foreach (string input in inputs)
                {
                    Match match = Regex.Match(input, pattern);
                    Console.WriteLine("Success : {0}, Expression : '{1}'", match.Success, input); 
                }
                Console.ReadLine();
