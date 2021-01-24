       //I'll let you input however you want to. Probably use console.ReadLine();
        string input = Console.ReadLine();
        int count;
        List<string> stringsList = new List<string> { "people", "desk", "orange", "yellow", "carrot", "pineapple"};
        
                foreach (string item in stringsList)
                {
                    if (input.Length > 1 && item.Length > 1)
                    {
                        if(input[input.Length - 1] == item[item.Length - 1])
                        {
                            //Same Last character
                            if(input[0] == item[0])
                            {
                                //Same first character
                                count += 1;
                            }
                        }
                    }
                }
                Console.WriteLine(count);
