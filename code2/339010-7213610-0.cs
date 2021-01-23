    private Dictionary<Control, int> OldValuesX = new Dictionary<Control, int>();
    
    public void SaveProperties()
    {
       foreach (var ctr in this.Controls)
         OldValuesX[ctr] = ctr.X;
    }
