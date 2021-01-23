      Timer tmr = new Timer();
      public Form1()
      {
         tmr.Interval = 10000;
         tmr.Tick += new EventHandler(tmr_Tick);
         tmr.Start();
         InitializeComponent();
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.ShowInTaskbar = false;
         this.Load += new EventHandler(Form1_Load);
      }
      void tmr_Tick(object sender, EventArgs e)
      {
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
         this.ShowInTaskbar = true;
         this.Size = new Size(300, 300);
      }
      void Form1_Load(object sender, EventArgs e)
      {
         this.Size = new Size(0, 0);
      }
