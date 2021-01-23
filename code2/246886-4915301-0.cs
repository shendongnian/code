    public bool CanEditCharacter { get { return SelectedCharacter != null; } }
    public void EditCharacter()
    {
       EventHandler h = EditingCharacter;
       if (EditingCharacter != null)
       {
          EditingCharacter(this, EventArgs.Empty);
       }
    }
