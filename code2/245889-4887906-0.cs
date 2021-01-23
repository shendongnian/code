    public partial class YourSecondForm : Form
    {
        object PreserveFromFirstForm;
    
        public YourSecondForm()
        {
           ... its default Constructor...
        }
    
        public YourSecondForm( object ParmFromFirstForm ) : base()
        {
           this.PreserveFromFirstForm = ParmFromFirstForm;
        } 
    
        private void YourSecondFormMethodToManipulate()
        {
           // you would obviously have to type-cast the object as needed
           // but could manipulate whatever you needed for the duration of the second form.
           this.PreserveFromFirstForm.Whatever = "something";
        }
    
    
    }
