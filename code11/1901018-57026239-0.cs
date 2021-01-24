    public partial class TableButton : UserControl
    {
        class TableButtonControlCollection : ControlCollection
        {
            TableButton owner;
            public TableButtonControlCollection(TableButton owner) : base(owner)
            {
                this.owner = owner;
            }
            public override void Add(Control value)
            {
                base.Add(value);
                value.Click += Value_Click;
            }
            private void Value_Click(object sender, EventArgs e)
            {
                owner.OnClick(EventArgs.Empty);
            }
        }
        protected override ControlCollection CreateControlsInstance()
        {
            return new TableButtonControlCollection(this);
        }
    }
