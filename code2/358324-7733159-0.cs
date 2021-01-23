    idUpdate.CombineLatest(queryStateUpdate, (id, qs) => new { id, qs }).Subscribe( anon =>
    {
      var id = anon.id;
      var queryState = anon.qs;
      //The roleId updated after the ObservationState updated
      if (id.Item2 > queryState.Item2)
      {
          //If the queryState is active, call execute
          if (observationState.Item1)
          {
             cache.Clear();
             execute.OnNext(roleId.Item1);
             return;
          }
          //If the id updated and the  state is suspended, cache it
          cache.Push(id.Item1);
      }
      //The observationState updated after the roleId
      else if (observationState.Item2 > roleId.Item2)
      {
         //If the observationState is active, and a roleId update has been cached, call execute
         if (observationState.Item1 == ObservationState.Active && cache.Count > 0)
         {
             execute.OnNext(cache.Pop());
             cache.Clear();
         }
      }});
