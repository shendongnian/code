    public class MyHyperLink : HyperLink
    {
        public string DefaultText { get; set; }
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public override string Text
        {
            get
            {
                return string.IsNullOrEmpty(base.Text) ? this.DefaultText : base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
