    public enum Resolution
    {
       High,
       Medium,
       Low
    }
    
    Dictionary<Resolution, string> Descriptions = new Dictionary<Resolution, string>();
    Descriptions.Add(Resolution.High, "1920x1080");
    Descriptions.Add(Resolution.Medium, "1280x720");
    Descriptions.Add(Resolution.Low, "800x600");
    
    comboBox2.DataSource = Descriptions.Values;
    
    public void testmethod(Resolution res)
    {
       string description = Descriptions[res];
       ...
    }
    
    public void testmethod2(string description)
    {
       Resolution res = Descriptions.Keys.ToList().Find(k => Descriptions[k].Equals(description));
       ...
    }
