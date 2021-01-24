public Form1()
{
    InitializeComponent();
    powerTextBox.Text = "0";
    torqueTextBox.Text = "0";
    rpmTextBox.Text = "0";
}
private void powerTextBox_TextChanged(object sender, EventArgs e)
{
    if(Double.TryParse(powerTextBox.Text, out double power)
       && Double.TryParse(rpmTextBox.Text, out double rpm))
    {
       if(rpm != 0)
       {
          torque = power / rpm * 9550;
          torqueTextBox.Text = Convert.ToString(torque);
       }
    }
    else
    {
       //Handle invalid inputs
       torqueTextBox.Text = "Wrong power or rpm";
    }
}
