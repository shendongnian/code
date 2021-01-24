c#
public MyTextContent 
{
 get => this.MyTextBox.Content; 
 set => this.MyTextBox.Text = value;
}
You can control the return value based on conditions (such as OK or Cancel buttons) if you like by using click events.  The window contains a DialogResult property.  The default is false, so you will need to set this somewhere.
this.DialogResult = true; // OK
Then in your main window's code behind, create a new instance of the window, assign it's property and show it.  This will need to be done during a click event of a button or some similar trigger
c#
var myDialog = new MyDialogWindow()
{
  MyTextContent = "Textbox Starting Value";
}
bool? result = myDialog.ShowDialog(); // Returns when the dialog window is closed.
if(result != null && result)
{
  this.LocalTextBox.Text = myDialog.MyTextContent; // Copy the text to the main textbox.
}
