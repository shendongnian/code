            using(impersonationContext = principal.Impersonate())
            {
              connection.Open();
              ...
              impersonationContext.Undo();
            }
       That's not exact, but it's close.
