    public Form1()
    {
        InitializeComponent();
        InitialiseDictionary();
        Series ser1 = new Series("My Series", 10);
        chart1.Series.Add(ser1);
        chart1.Series["My Series"].Points.DataBindXY(dict1.Keys, dict1.Values);
    }
    
