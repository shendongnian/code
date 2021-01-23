    using (var db = new Entitites())
    {
        // Attach the object on this context
        db.Attach(tool);
        // Change the state of the context to ensure update
        db.ObjectStateManager.GetObjectStateEntry(tool).SetModified();
        // ClientWins, flawless victory
        db.Refresh(RefreshMode.ClientWins, tool);
    }
