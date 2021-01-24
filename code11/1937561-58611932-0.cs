                string[] inputs = { 
                                  "this is test",
                                  "this is test=param1,param2,param3",
                                  "use file \"c:\\test file.txt\"=param1 , param2,param3",
                                  "log off",
                                  "use object \"c:\\test file.txt\"=\"C:\\Users\\layer.shp\" | ( object = 10 ),param2"
                              };
                foreach (string input in inputs)
                {
                    List<string> splitArray;
                    if (!input.Contains("="))
                    {
                        splitArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    }
                    else
                    {
                        int equalPosition = input.IndexOf("=");
                        splitArray = input.Substring(0, equalPosition).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        string end = input.Substring(equalPosition + 1);
                        splitArray.AddRange(end.Split(new char[] { ',' }).ToList());
                    }
                    string output = string.Join(",", splitArray.Select(x => x.Contains("\"") ? x : "\"" + x + "\""));
                    Console.WriteLine(output);
                }
                Console.ReadLine();
