    public int CountBit(string mask)
            {
                
                int ones=0;
                Array.ForEach(mask.Split('.'),(s)=>Array.ForEach(Convert.ToString(int.Parse(s),2).Where(c=>c=='1').ToArray(),(k)=>ones++));
              return ones
    
            }
