    // example usage: SetGlow ("Red");
    void SetGlow (string colour)
    {
       SetGlow (Controls, colour);
    }
  
    void SetGlow (ControlContainer controls, string colour)
    {
      foreach (Control control in controls)
      {
        if (control.Tag is a string) // syntax escapes me
        {
          string tag = (string) control.Tag;
          if (tag.StartsWith ("LED="))
          {
            if (tag == ("LED=" + colour))
            {
              // enable glow
            }
            else
            {
              // disable glow
            }
          }
        }
        SetGlow (control.Controls, colour);
      }
    }
