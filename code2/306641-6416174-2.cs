IEnumerable&lt;Control> GetMarkedControls(ControlCollection controls)
{
  foreach(Control c in controls)
  {
    var props = c.GetType().Properties();
    if(props.Count(x => x.GetCustomAttributes(false).OfType&lt;YourAttribute>().Count() > 0) > 0)
      yield return c;
    foreach (Control ic in GetMarkedControls(c.Controls))
      yield return ic;
  }
}
