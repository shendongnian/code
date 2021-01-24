    public partial class LeaderBoard : Page
    {
        public int MyProperty { get; set; }
        //stuff...
    
        public void Foo()
        {
            textBlock1.Text = Convert.ToString(this.MyProperty);
        }
    }
