public partial class MyForm
{
  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    switch ( keyData )
    {
      case Keys.Escape:
        Close();
        return true;
    }
    return base.ProcessCmdKey(ref msg, keyData);
  }
}
So anywhere the user is, no matter the active control, keys are catched and you can manage what you want. You can also add any UX condition like an `AllowClose` conditional variable.
To not repeat the code you can create a custom form and replace the standard Form base class used by the Visual STudio Designer like suggested by @Cid.
