public partial class MainMenuForm : Form
{
   public MainMenuForm()
   {
      InitializeComponent();            
   }
   public void SetRole(string role)
   {
       lblRole.Text = role;
   }
}
and then
private void btnOk_Click(object sender, EventArgs e)
{
    //...
    // Access to Main Menu for Authorized Users
    if (DT.Rows.Count == 1)
    {
        MainMenuForm MainMenu = new MainMenuForm();
		MainMenu.SetRole(DT.Rows[0][0].ToString());
        MainMenu.Show();
        this.Hide();
    }
}
