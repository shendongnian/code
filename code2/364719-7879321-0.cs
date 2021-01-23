    public Stack Sum()
    {
        int carry = 0;
        for (int i = 0; i < s.Count; i++)
        {
            var result = Convert.ToInt32(s1.Pop()) + Convert.ToInt32(s2.Pop()) 
                         + carry;
            res.Push(result%10);
            carry = result - result % 10;
        }
        
        var carryStream = carry.ToString();
        for(int i=carryStream.Length-1;i>=0;i--)
        {
             res.push(Convert.ToInt32(carryStream.Substring(i,1);
        }
        return res;
    }
