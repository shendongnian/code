string result = array.ToString(); 
should be
string result = item.ToString();
Here's one solution:
            foreach (var item in array)
            {
                string result = "";
                if (item == 0)
                    result = "0";
                else
                {
                    for (int i = 0; i < item; i++)
                        result += "X";
                }   
                                    
                Console.WriteLine(result);
            }
