    First create list of Tuples which contains numbers and corresponds.
    Then a method/loops to iterate and return result.
    IEnumerable<Tuple<int, string>> data = new List<Tuple<int, string>>()
                    {
                      new Tuple<int, string>( 1, "I"),
                      new Tuple<int, string>( 4, "IV" ),
                      new Tuple<int, string>( 5, "V" ),
                      new Tuple<int, string>( 9, "IX" ),
                      new Tuple<int, string>( 10, "X" ),
                      new Tuple<int, string>( 40, "XL" ),
                      new Tuple<int, string>( 50, "L" ),
                      new Tuple<int, string>( 90, "XC" ),
                      new Tuple<int, string>( 100, "C" ),
                      new Tuple<int, string>( 400, "CD" ),
                      new Tuple<int, string>( 500, "D" ),
                      new Tuple<int, string>( 900, "CM"),
                      new Tuple<int, string>( 1000, "M" )
                    };
    
        
     public string ToConvert(decimal num)
                { 
                     data = data.OrderByDescending(o => o.Item1).ToList(); 
                    List<Tuple<int, string>> subData = data.Where(w => w.Item1 <= num).ToList();
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in subData)
                    {
                        if (num >= item.Item1)
                        {
                            while (num >= item.Item1)
                            {
                                num -= item.Item1;
                                sb.Append(item.Item2.ToUpper());
                            }
                        }
                    } 
                    return sb.ToString();
                }
                     
             
