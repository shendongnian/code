                var dayCode = "MWF";
                var daysArray = new List<string>();
                var list = new Dictionary<string, string>{
                    {"M", "Monday"},
                    {"T", "Tuesday"},
                    {"W", "Wednesday"},
                    {"R", "Thursday"},
                    {"F", "Friday"},
                    {"S", "Saturday"},
                    {"U", "Sunday"}
                };
    
                for(int i = 0,max = dayCode.Length; i < max; i++)
                {
                    var tmp = dayCode[i].ToString();
                    if(list.ContainsKey(tmp))
                    {
                        daysArray.Add(list[tmp]);
                    }
                }
                Console.WriteLine(string.Join(",", daysArray));
