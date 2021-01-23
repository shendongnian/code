    public partial class frmYourForm : Form
    {
        public frmYourForm()
        {
           Load += YourPreparationHandler;
        }
    
        private void YourPreparationHandler(object sender, EventArgs e)
        {
            // Do you code to prepare list, combos, query, bind, whatever
        }
    }
