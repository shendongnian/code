    public partial class MyTableLayoutPanel : TableLayoutPanel
    {
            public MyTableLayoutPanel()
            {
                InitializeComponent();
            }
    
            public MyTableLayoutPanel(IContainer container)
            {
                container.Add(this);
                InitializeComponent();
            }
    
            /// <summary>
            /// Double buffer
            /// </summary>
            [Description("Double buffer")]
            [DefaultValue(true)]
            public bool dBuffer
            {
                get { return this.DoubleBuffered; }
                set { this.DoubleBuffered = value; }
            }
    }
