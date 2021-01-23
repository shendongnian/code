     public GraphFrm()
      {
         InitializeComponent();
         //new PrintDocument object to reset default one
         chart.Printing.PrintDocument = new System.Drawing.Printing.PrintDocument();
         //set up events
         chart.Printing.PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDocument_PrintPage);
         chart.Printing.PrintDocument.BeginPrint +=new System.Drawing.Printing.PrintEventHandler(PrintDocument_BeginPrint);
         chart.Printing.PrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(PrintDocument_EndPrint);
         //default print setting like margins and landscape
         chart.Printing.PrintDocument.DefaultPageSettings.Margins.Bottom = 50;
         chart.Printing.PrintDocument.DefaultPageSettings.Margins.Top = 50;
         chart.Printing.PrintDocument.DefaultPageSettings.Margins.Left = 50;
         chart.Printing.PrintDocument.DefaultPageSettings.Margins.Right = 50;
         chart.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
         chart.Printing.PrintDocument.DefaultPageSettings.Color = true;
         ...
      }
      public void Print()
      {
         //print method with show print dialog
         chart.Printing.Print(true);
      }
      void PrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         //set print color
         PrintChartColorSet();
      }
      void PrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
      {
         //restore colors
         PrintChartColorRestoreDefault();
      }
      void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
         //print chart into rectangle defined by margins
         Rectangle chartPosition = new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Width, e.MarginBounds.Height);
         chart.Printing.PrintPaint(e.Graphics, chartPosition);
      }
      Color BackColor, BorderlineColor, CaBackColor, CaBorderColor, AxColor, LeBackColor, LeForeColor;
      void PrintChartColorSet()
      {
         BackColor = chart.BackColor;
         chart.BackColor = Color.White;
         BorderlineColor = chart.BorderlineColor;
         chart.BorderlineColor = Color.White;
         CaBackColor = chart.ChartAreas[0].BackColor;
         chart.ChartAreas[0].BackColor = Color.White;
         CaBorderColor = chart.ChartAreas[0].BorderColor;
         chart.ChartAreas[0].BorderColor = Color.Black;
         AxColor = chart.ChartAreas[0].Axes[0].LineColor;
         foreach(Axis a in chart.ChartAreas[0].Axes)
         {
            a.LineColor = Color.Black;
            a.TitleForeColor = Color.Black;
            a.MajorGrid.LineColor = Color.Black;
            a.MajorTickMark.LineColor = Color.Black;
            a.MinorGrid.LineColor = Color.Black;
            a.MinorTickMark.LineColor = Color.Black;
            a.LabelStyle.ForeColor = Color.Black;
         }
         LeBackColor = chart.Legends[0].BackColor;
         chart.Legends[0].BackColor = Color.White;
         LeForeColor = chart.Legends[0].ForeColor;
         chart.Legends[0].ForeColor = Color.Black;
      }
      void PrintChartColorRestoreDefault()
      {
         chart.BackColor = BackColor;
         chart.BorderlineColor = BorderlineColor;
         chart.ChartAreas[0].BackColor = CaBackColor;
         chart.ChartAreas[0].BorderColor = CaBorderColor;
         foreach(Axis a in chart.ChartAreas[0].Axes)
         {
            a.LineColor = AxColor;
            a.TitleForeColor = AxColor;
            a.MajorGrid.LineColor = AxColor;
            a.MajorTickMark.LineColor = AxColor;
            a.MinorGrid.LineColor = AxColor;
            a.MinorTickMark.LineColor = AxColor;
            a.LabelStyle.ForeColor = AxColor;
         }
         chart.Legends[0].BackColor = LeBackColor;
         chart.Legends[0].ForeColor = LeForeColor;
      }
