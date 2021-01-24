    TChart _tChart;
    public Form1()
    {
        InitializeComponent();
        _tChart = new TChart();
        _tChart.Dock = DockStyle.Fill;
        _tChart.Series.Add(typeof(Line)).FillSampleValues();
        _tChart.Series.Add(typeof(Line)).FillSampleValues();
        _tChart.Series.Add(typeof(Line)).FillSampleValues();
        _tChart.Series[0].YValues.Value = _tChart.Series[2].YValues.Value.Select(x => x * 100).ToArray();
        _tChart.Header.Text = Utils.Version;
        _tChart[0].CustomVertAxis = _tChart.Axes.Custom.Add();
        _tChart[0].CustomVertAxis.Title.Text = "Axis One Title";
        _tChart[0].CustomVertAxis.Title.Angle = 90;
        _tChart[1].CustomVertAxis = _tChart.Axes.Custom.Add();
        _tChart[1].CustomVertAxis.Title.Text = "Axis Two Title";
        _tChart[1].CustomVertAxis.Title.Angle = 90;
        _tChart[2].CustomVertAxis = _tChart.Axes.Custom.Add();
        _tChart[2].CustomVertAxis.Title.Text = "Axis Three Title";
        _tChart[2].CustomVertAxis.Title.Angle = 90;
        int leftIndex = 0, rightIndex = 0;
        for (int i = 0; i < this._tChart.Axes.Custom.Count; i++)
        {
            var axis = this._tChart.Axes.Custom[i];
            axis.Visible = true;
            axis.PositionUnits = Steema.TeeChart.PositionUnits.Pixels;
            axis.RelativePosition = 0 - (axis.OtherSide ? rightIndex++ : leftIndex++) * (i == 1 ? 80: 70);
        }
        _tChart.Panel.MarginLeft = 30;
        this.Controls.Add(_tChart);
    }
