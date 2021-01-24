            static void Main(string[] args)
            {
                string[] inputs = { 
                                    "[MyCompany LTD] [AB0123456789] [Not so long address in country]",
                                    "[My investment properties LTD] [AB0123456789] [street 24 mycity 2233 country]"
                                  };
                foreach (string input in inputs)
                {
                    Console.WriteLine("Parsing : '{0}'", input);
                    string[] splitArray = input.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    string remainder = "";
                    int index = 0;
                    string line = "";
                    do
                    {
                        if (index < splitArray.Length)
                        {
                            line = remainder + splitArray[index];
                        }
                        else
                        {
                            line = remainder;
                        }
                        remainder = string.Empty;
                        if (line.Trim().Length > 0)
                        {
                            string processLine = remainder + line;
                            remainder = string.Empty;
                            if (processLine.Length > 20)
                            {
                                remainder = processLine.Substring(20);
                                processLine = processLine.Substring(0, 20);
                            }
                            Console.WriteLine("\t{0}", processLine);
                        }
                        if (index < splitArray.Length) index++;
                    } while ((index <= 4) && ((index < splitArray.Length) || (remainder.Length > 0)));
                }
                Console.ReadLine();
            }
