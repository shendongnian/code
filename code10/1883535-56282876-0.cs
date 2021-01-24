     public static bool IsStrong(string pass)
            {
               
                bool isStrong = false;
                int num = 0;
                var stringArr = pass.ToCharArray();
                var numsArr = new List<int>();
              
                foreach (var a in stringArr)
                {
                    if (int.TryParse(a.ToString(), out num))
                    {
                        numsArr.Add(num);
                    }
                }
    
                if (numsArr.Any())
                {
                    for (int i = 1; i < numsArr.Count(); i++)
                    {
                        if(numsArr[i] - numsArr[i-1] != 1)
                        {
                            isStrong = true;
                        }
                    }
                }
    
                return isStrong;
    
            }
