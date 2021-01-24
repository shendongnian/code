    public partial class AutoPay : Form
    {
      private string[] headerArray;  <-- declare here....
      public AutoPay()
      {
        InitializeComponent();
        headerArray = new string[2];
      }
      public void HeaderInformation(string dateAndTime, string fileNumber)
      {
        dateAndTime = DateTime.Now.ToString();
        fileNumber = txtFileNumber.Text;
        headerArray = new string[2];
        headerArray[0] = dateAndTime;
        headerArray[1] = fileNumber;
      }
      public void BtnSave_Click(object sender, EventArgs e)
      {
        HeaderInformation(headerArray[0], headerArray[1]);
      }
    }
