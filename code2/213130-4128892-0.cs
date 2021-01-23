    public static Control FindControlRecursive(Control Root, string Id)
    {
      if (Root.ID == Id)
        return Root;
      foreach (Control c in Root.Controls)
      {
        Control fc = FindControlRecursive(c, Id);
        if (fc != null)
          return fc;
      }
      return null;
    }
