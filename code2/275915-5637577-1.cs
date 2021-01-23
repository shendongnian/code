    int num = 92345;
                string strNum = Convert.ToString(num);
               
                var divisibleby2 = from c in strNum
                                   where int.Parse(c.ToString()) % 2 == 0
                                   select c.ToString();
    
                var notDivisibleby2 = from c in strNum
                                   where int.Parse(c.ToString()) % 2 != 0
                                      select c.ToString();
    
                int int_divisibleby2num = int.Parse(String.Join("", divisibleby2.ToArray()));
                int int_Notdivisibleby2num = int.Parse(String.Join("", notDivisibleby2.ToArray()));
