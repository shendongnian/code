                var intArray = creditCardNumber.ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
                var result = new List<int>();
    
                for(int i=0; i<intArray.Length; i++){
                   
                    if((i % 2) == 0)
                      result.Add(intArray[i] * 2);
                    else
                        result.Add(intArray[i]);
                }
    
                Console.Write(string.Concat(result.Select(o => o.ToString())));
 
