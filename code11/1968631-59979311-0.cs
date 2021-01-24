private void OnButtonSearchPixelClick(object sender, EventArgs e)
{
    // 01. get hex value from input field
    string inputHexColorCode = textBox1.Text;
    Task.Run(() => {
        SearchPixel(inputHexColorCode);
    });
}
## Caveat
As your code will be running in a thread other than WinForms' STA thread it is not possible to interact with any object that WinForms is using without doing an invoke.
For example:
Task.Run(() => {
    label1.Text = "Test";
});
Will cause an `InvalidOperationException`, as you're attempting to access an object that WinForms expects to only be accessed in its single thread apartment.
You must tell the STA thread to invoke an action, which will cause the code to be run in the STA thread. Like so:
Task.Run(() => {
    //Code in here will run in a thread pool
    this.Invoke((Action)delegate {
        //Code in here will run in the STA thread
       label1.Text = "Test";
    });
});
