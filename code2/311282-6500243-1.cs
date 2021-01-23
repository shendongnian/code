        namespace String_Writer
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string batname = "test.txt";
                    string theedit = "Testing one two three four\n\nfive six seven eight.";
                    using(StreamWriter sw = File.CreateText("C:\\Users\\Kriis\\Desktop\\" + batname))
                    {
                        using (StringReader reader = new StringReader(theedit))
                        {
                            string line = string.Empty;
                            do
                            {
                                line = reader.ReadLine();
                                if (line != null)
                                {
                                    sw.WriteLine(line);
                                }
                            } while (line != null);
                        }
                    }
                }
            }
        }
