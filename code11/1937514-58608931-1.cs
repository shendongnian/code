public partial class EscapableForm
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
Overriding the method is here better than using an event since it allows a better design consistency.
So anywhere the user is, no matter the active control, keys are catched and you can manage what you want. You can also add any UX condition like an `AllowClose` conditional variable.
To not repeat the code you can create the custom form class file and replace the standard Form base class used by the Visual STudio Designer in any final form like suggested by @Cid.
