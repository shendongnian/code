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
    Enum.TryParse(text, out Key key1);
    Thread.Sleep(40);
    Invoke(() => label1.Text = "ready"); // must use Invoke 
                                         // to access Label 
                                         // created by the UI thread
    if (Keyboard.IsKeyDown(Key.key1))
    {
        Thread.Sleep(40);
        SendKeys.SendWait("e");
    }
}
