    public class SomeClass : BaseControl
    {
        public event EventHandler PersonSelected;
        
        public string Name{get;set;}
        protected void FindUser()
        {
            var find = new Button {ID = (ToString() + "search"), Text = "Search"};
                find.Click += delegate(object sender, EventArgs e)
                                  {
                                      if (PersonSelected!= null)
                                      {
                                          //forward this event to the page's event handler
                                          PersonSelected(this, e);
                                      }
                                  }; 
         }
    }
    public class SomeOtherClass : Page
    {
        public void Main()
        {
           var sp = (SomeClass)Control;
                            sp.PersonSelected += BtnClick;
         }
        public void BtnClick(object sender, EventArgs e)
        {
            //Get some value from the (SomeClass)Control here
         }
    }
