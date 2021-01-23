    public Stack Sum()
    {
        int carry = 0 ;
        for (int i = 0; i < s.Count; i++)
        {
            int sum = Convert.ToInt32(s1.Pop()) + Convert.ToInt32(s2.Pop()) + carry;
            if(sum > 10) { carry = 1} else {carry = 0;} // you might want to check more than 10 here
             res.push(sum);
        }
        return res;
    }
