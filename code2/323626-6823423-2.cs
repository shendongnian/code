            StringBuilder result = new StringBuilder();
            string data = "J6      INT-00113G  227.905  174.994  180  SOIC8\r\nJ3      INT-00113G  227.905  203.244  180  SOIC8\r\nU13     EXCLUDES    242.210  181.294  180  QFP128\r\nU3      IC-00276G   236.135  198.644  90   BGA48\r\nU12     IC-00270G   250.610  201.594  0    SOP8\r\nJ1      INT-00112G  269.665  179.894  180  SOIC16\r\nJ2      INT-00112G  269.665  198.144  180  SOIC16\r\n";
            // Split on new line
            int startchar = 0;
            int lastspace = 0;
            for(int i = 0; i < data.Length - 1; i++)
            {
                char current = data[i];
                if (current == ' ')
                {
                    // remember last space
                    lastspace = i;
                }
                else if (current == '\n')
                {
                    result.AppendLine(data.Substring(startchar, lastspace - startchar));
                    if(i != data.Length - 1)
                    {
                        startchar = i + 1;
                        lastspace = startchar;
                    }
                }
            }
            Console.Write(result.ToString());
