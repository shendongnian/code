IEnumerable&lt;WebControl> GetMarkedControls(ControlCollection controls)
{
  foreach(Control c in controls)
  {
    if(c is WebControl)
    {
      var wc = c as WebControl;
      if (wc.Attributes.FirstOrDeafult(x => x.Name == "yourAttribute") != null)
        yield return c;
    }
    
    foreach (Control ic in GetMarkedControls(c.Controls))
      yield return ic;
  }
}
