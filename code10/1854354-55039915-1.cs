        }
        
          private int GetUniqRandomNumber()
            {
                int num = Random.Range(1, 11);
        
                if (usedNum.Contains(num))
                {
                    num = GetUniqRandomNumber();
                }
                else {
                    usedNum.Add(num);
                }
                if(usedNum.Count == 10) //  THIS WILL PREVENT entering infinite LOOP - 10  should be yourMax number -1 
                {
                    usedNum.Clear();
                }
                return num;
            }
