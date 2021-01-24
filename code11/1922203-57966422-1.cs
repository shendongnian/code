    private void PlotDisplayWindow_Load(object sender, EventArgs e)
    {
                this.plotView1.Model = new PlotModel { Title = "Example 1" };
                
    }
    
    public void Update(IEnumerable<DataPoint> points)
    {
                this.plotView1.Model.Series.Add(new LineSeries { ItemsSource = points });
                this.plotView1.InvalidatePlot(true);
    }
