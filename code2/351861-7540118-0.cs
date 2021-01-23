    public void Filter(Func<string> string1, Func<string> string2)
    {
    var result = item =>
            {                
                OrdsRlsd vitem = item as OrdsRlsd;                
    
                if (vitem.OrderNo >= Convert.ToInt32(string1.Invoke()) && vitem.OrderNo <= Convert.ToInt32(string2.Invoke()))
                {
                    return true;
                }
                return false;
            };  
    }
