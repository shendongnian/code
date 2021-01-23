      public Form1()
      {
         InitializeComponent();
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.ShowInTaskbar = false;
         this.Load += new EventHandler(Form1_Load);
      }
      void Form1_Load(object sender, EventArgs e)
      {
         this.Size = new Size(0, 0);
      }
