    private readonly PlotView _pv;
 
    public Form1()
    {
        InitializeComponent();
    //moved initialization from btnCalculate_Click
        _pv = new PlotView();
        this.Controls.Add(_pv);
        _pv.Location = new Point(0, 0);
        _pv.Size = new Size(500, 500);
        _pv.Model = new PlotModel {Title = "Program"};
        _pv.Model.InvalidatePlot(true);
    }
    
    private void btnCalculate_Click(object sender, EventArgs e)
    {
        // keep old code Except _pv initialization   
        
        _pv.Model.Series.Add(Pkoline);//typo in old code
    }
    
    private void clearBtn_Click(object sender, EventArgs e)
    {
        _pv.Model.InvalidatePlot(true);
        _pv.Model.Series.Clear();        
    }
