    public partial class Form1 : Form
    {
        public Form1()
        {
            string userName = Environment.UserName.ToLower();
            if(isAuthorized(userName)){
                InitializeComponent();
            }
            else {
                MessageBox.Show("You are not authorized");
                this.close();
            }
        }
    }
