    Public string TIDstring
    {
    get { return (this.TID + 5).toString(); }
    set
        {
           int val = 0;
           if (int.TryParse(value, out val)
               this.TID = val - 5;
           else
               throw new Exception("Invalid TID Value")
        }
    
    }
