    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            private Random rnd = new Random();
    
            public Form1()
            {
                InitializeComponent();
                SetupChart();
            }
    
            private void SetupChart()
            {
                chart1.Series.Clear();
                chart1.Legends.Clear();
    
                ChartArea area = chart1.ChartAreas[0];
                area.AxisX.IntervalType = DateTimeIntervalType.Hours;
                area.AxisX.LabelStyle.Format = "HH";
                area.AxisX.Interval = 1.0D;
    
                Series s = new Series("TimeData");
                s.ChartType = SeriesChartType.Point;
                s.ChartArea = area.Name;
                s.XValueType = ChartValueType.DateTime;
                s.YValueType = ChartValueType.Int32;
    
                DateTime t = DateTime.Today;
    
                TimeSpan timeIncrement = new TimeSpan(0, 15, 0);
    
                for (Int32 i = 0; i <= 19; i++)
                {
                    s.Points.AddXY(t, rnd.Next(5, 16));
                    t = t.Add(timeIncrement);
                }
    
                chart1.Series.Add(s);
                chart1.FormatNumber += chart1_FormatNumber;
    
            }
    
    
            private void chart1_FormatNumber(object sender, FormatNumberEventArgs e)
            {
                if (e.ElementType == ChartElementType.AxisLabels)
                {
                    DateTime d1 = DateTime.FromOADate(e.Value);
                    DateTime d2 = d1.AddHours(1);
                    e.LocalizedValue = $"{d1:HH}-{d2:HH}";
                }
            }
    
        }
    }
