csharp
//In a form
public void MyButton_Clicked(object sender, EventArgs e)
{
    string[] args = Environment.GetCommandLineArgs();
    MessageBox.Show(string.Join(Environment.NewLine, args));
}
