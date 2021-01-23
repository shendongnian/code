    private IList<double> _preTvoltage = new List<double>();
    public IEnumerable<double> preTvoltage 
    {
        get 
        {
            return preTvoltage.AsEnumerable();
        } 
    }
    public void AddTvoltage(double item)
    {
      _preTvoltage.Add(item);
    }
