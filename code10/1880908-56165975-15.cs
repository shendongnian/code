    public partial class SearchForm : Form
    {
        ISearch myOwner = null;
        string currentQuery = string.Empty;
        string otherValues = string.Empty;
        public SearchForm() => InitializeComponent();
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Type type = this.Owner.GetType();
            if (typeof(ISearch).IsAssignableFrom(type))
            {
                myOwner = (ISearch)this.Owner;
                this.currentQuery = myOwner.Query;
                this.otherValues = myOwner.GetSomeOtherValue();
                Console.WriteLine(this.currentQuery);
                Console.WriteLine(myOwner.Other);
                Console.WriteLine(this.otherValues);
            }
            else
            {
                throw new NotSupportedException("My Owner is not the right type!");
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            myOwner.ReturnValue = true;
            base.OnFormClosing(e);
        }
    }
