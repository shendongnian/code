    using System.Linq;
    private void ClearPersonControls(Panel panel)
    {
      foreach ( var control in panel.Controls.OfType<PersonControl>().ToList() )
        panel.Controls.Remove(control);
    }
