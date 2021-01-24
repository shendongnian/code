            StringBuilder msg = new StringBuilder();
            using (var p = new ChoJSONReader("*** YOUR JSON FILE PATH ***")
                .WithJSONPath("$.inputFile[*]")
                )
            {
                using (var w = new ChoCSVWriter(msg))
                {
                    w.Write(p);
                }
                Console.WriteLine(msg.ToString());
            }
