    public async Task GetCards(CancellationToken ct)
    {
       try
       {
          App.viewablePhrases = App.DB.GetViewablePhrases(Settings.Mode, Settings.Pts, ct);
          await CheckAvailability(ct);
       }
       catch(OperationCanceledException ex)
       {
           // handle the cancelation...
       }
       catch
       {
           // handle the unexpected exception
       }
    }
