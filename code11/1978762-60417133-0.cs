                string[] inputs = {
                                      "CR 722-2018",
                                      "CR7222018",
                                      "-CR 7222018"
                                  };
                foreach (string input in inputs)
                {
                    string digits = string.Join("", input.Where(x => char.IsDigit(x)));
                    string output = string.Format("CP-41-CR-000{0}-{1}", digits.Substring(0, 3), digits.Substring(3));
                    Console.WriteLine(output);
                }
                Console.ReadLine();
