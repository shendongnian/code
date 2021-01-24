public static class UIExtensions
{
  public static void Present(this Form form, Form parent)
  {
    form.MdiParent = parent;
    form.Show();
  }
}
Then you can just `actorUI.Present(this);`
