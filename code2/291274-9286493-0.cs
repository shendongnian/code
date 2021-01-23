    public partial class Line : Label
    {
        public override bool AutoSize
        {
            get
            {
                return false;
            }
        }
        public override Size MaximumSize
        {
            get
            {
                return new Size(int.MaxValue, 2);
            }
        }
        public override Size MinimumSize
        {
            get
            {
                return new Size(1, 2);
            }
        }
        public override string Text
        {
            get
            {
                return "";
            }
        }
        public Line()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.Height = 2;
            this.BorderStyle = BorderStyle.Fixed3D;
        }
    }
