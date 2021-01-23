    /// <summary>
    /// When the database context is submitted.
    /// </summary>
    /// <param name="failureMode">
    /// the submit failure mode
    /// </param>
    public override void SubmitChanges(ConflictMode failureMode)
    {
      foreach (var insert in changeSet.Inserts.OfType<IHaveEstimation>())
      {
        var estimtation = insert.GetEstimationDate();
        // handle auditing, etc.
      }
      // do same for update and delete change sets
    }
