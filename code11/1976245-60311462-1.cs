    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    namespace WindowsFormsApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                var chart = new Chart();
                chart.ChartAreas.Add(new ChartArea());
                var series = new Series();
                series.Points.AddXY(1.0, 42.0);
                series.Points.AddXY(2.0, 47.0);
                series.Points.AddXY(3.0, 53.0);
                chart.Series.Add(series);
                chart.Location = new System.Drawing.Point(10, 10);
                chart.Size = new System.Drawing.Size(500, 400);
                this.Controls.Add(chart);
            }
        }
    }
