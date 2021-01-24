    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        Point p = Cursor.Position;
        label1.Text = "x= " + p.X.ToString();
        label2.Text = "y= " + p.Y.ToString();
    }
    class Form1ControlCollection : ControlCollection
    {
        Form1 owner;
        internal Form1ControlCollection(Form1 owner) : base(owner)
        {
            this.owner = owner;
        }
        public override void Add(Control value)
        {
            base.Add(value);
            value.MouseMove += Value_MouseMove;
        }
        private void Value_MouseMove(object sender, MouseEventArgs e)
        {
            owner.OnMouseMove(e);
        }
    }
    protected override Control.ControlCollection CreateControlsInstance()
    {
        return new Form1ControlCollection(this);
    }
