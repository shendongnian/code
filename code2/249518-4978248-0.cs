    public void seperatePMChattersNames(string TwoNames)
            {
                    Console.WriteLine(TwoNames);
                    int x = TwoNames.IndexOf("@2");
                    int y = TwoNames.IndexOf("@3");
                    string nameone = TwoNames.Substring(0, x);
                    string nametwo = TwoNames.Substring(y+2);
                    Console.WriteLine(nameone);
                    Console.WriteLine(nametwo);
            }
