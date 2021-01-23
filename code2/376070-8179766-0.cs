    context.Database.Connection.StateChanged += (sender, args) =>
      if (args.CurrentState == ConnectionState.Open) {
        activateAppRole((DbConnection)sender, ...);
      }
    }
