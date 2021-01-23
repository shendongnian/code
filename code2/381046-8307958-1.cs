           public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }
        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);
        }
        private void Chart_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
            SetSize();
        }
        private void CreateGraph(ZedGraphControl zg1)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.XAxis.Type = AxisType.Date;
            PointPairList PPLa = new PointPairList();
            PointPairList PPLb = new PointPairList();
            PointPairList PPLc = new PointPairList();
            PointPairList PPLd = new PointPairList();
            PointPairList PPLe = new PointPairList();
            PointPairList PPLf = new PointPairList();
            int Max = 1;
            for (int i = 0; i < Max; i++)
            {
                DateTime dtime = DateTime.Now;
                //int a = ctrscan.analyzeNewScanQuality1A();
                //int b = ctrscan.analyzeNewScanQuality1B();
                //int c = ctrscan.analyzeNewScanQuality1C();
                //int d = ctrscan.analyzeNewScanQuality1D();
                //int e = ctrscan.analyzeNewScanQuality1E();
                //int f = ctrscan.analyzeNewScanQuality1F();
                int a = 1;
                int b = 1;
                int c = 2;
                int d = 1;
                int e = 3;
                int f = 2;
                double date = (double)new XDate(dtime);
                PPLa.Add(date, (double)a);
                PPLb.Add(date, (double)b);
                PPLc.Add(date, (double)c);
                PPLd.Add(date, (double)d);
                PPLe.Add(date, (double)e);
                PPLf.Add(date, (double)f);
                BarItem myBara = myPane.AddBar("Bar A", PPLa, Color.Red);
                BarItem myBarb = myPane.AddBar("Bar B", PPLb, Color.Blue);
                BarItem myBarc = myPane.AddBar("Bar C", PPLc, Color.Green);
                BarItem myBard = myPane.AddBar("Bar D", PPLd, Color.Black);
                BarItem myBare = myPane.AddBar("Bar E", PPLe, Color.Yellow);
                BarItem myBarf = myPane.AddBar("Bar F", PPLf, Color.Orange);
                zedGraphControl1.AxisChange();
               // sleep(1 minute);
                
            }
            zg1.AxisChange();
        }
        private void Chart_Resize(object sender, EventArgs e)
        {
            SetSize();
        }
    }
