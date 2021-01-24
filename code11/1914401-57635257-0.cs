cs
using MouseKeyboardLibrary;
//....
//...
MouseHook mHook = new MouseHook();
public void Form1_Show()
{
	mHook.MouseDown += new MouseEventHandler(SomeMethod);
	mHook.Start();
}
public void SomeMethod(object sender, MouseEventArgs e)
{
	if(e.Button == MouseButtons.Left)
	{
		//do something
	}
}
