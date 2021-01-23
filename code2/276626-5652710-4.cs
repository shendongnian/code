    using System;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace ExampleApplication
    {
        public class Form1 : Form
        {
    
            #region designer-generated-code
            private System.ComponentModel.IContainer components = null;
    
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            private void InitializeComponent()
            {
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
                System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
                this.button1 = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
                this.SuspendLayout();
                // 
                // chart1
                // 
                this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                chartArea1.Name = "ChartArea1";
                this.chart1.ChartAreas.Add(chartArea1);
                legend1.Name = "Legend1";
                this.chart1.Legends.Add(legend1);
                this.chart1.Location = new System.Drawing.Point(12, 12);
                this.chart1.Name = "chart1";
                series1.ChartArea = "ChartArea1";
                series1.Legend = "Legend1";
                series1.Name = "Series1";
                this.chart1.Series.Add(series1);
                this.chart1.Size = new System.Drawing.Size(733, 192);
                this.chart1.TabIndex = 0;
                this.chart1.Text = "chart1";
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(620, 210);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(125, 40);
                this.button1.TabIndex = 1;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(757, 262);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.chart1);
                this.Name = "Form1";
                this.Text = "Form1";
                ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
            private System.Windows.Forms.Button button1;
            #endregion
    
            public Form1()
            {
                InitializeComponent();
            }
    
            public void AddDataPoint(myData d)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<myData>(this.AddDataPoint), new object[] { d });
                }
                else
                {
                    chart1.Series[0].Points.AddXY(d.X, d.Y);
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                new Thread(new ParameterizedThreadStart(worker)).Start(new Action<myData>(this.AddDataPoint));
            }
            private void worker(object obj)
            {
                var _delegate = (Action<myData>)obj;
                for (int x = 0; x < 50; x++)
                {
                    _delegate(new myData { X = x, Y = 2 * x });
                    Thread.Sleep(1000);
                }
            }
        }
        public class myData
        {
            public int X;
            public int Y;
        }
    }
