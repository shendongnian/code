c#
private void Form1_Load(object sender, EventArgs e)
{
    Thread TH = new Thread(PressBind); //I cant make thread for this method
    TH.SetApartmentState(ApartmentState.STA);
    CheckForIllegalCrossThreadCalls = false;
    TH.Start("some-text" /* here you pass the text */);
}
private void TxBxKTB_TextChanged_1(object sender, EventArgs e)
{
    TextBox objTextBox = (TextBox)sender;
    string text = objTextBox.Text;
    label2.Text = $"the bind key is {text}";
    PressBind(text);
}
void PressBind(object state)
{
    string text = (string)state; // cast object parameter back to string
    // do other things...
    // must use InvokeRequired + Invoke if accessing Label 
    // created by the UI thread
    if (InvokeRequired)
    {    
       Invoke(() => label1.Text = "ready"); 
    }
    else
    {
       label1.Text = "ready"; // we're on the UI thread
    }
    // do other things...
}
