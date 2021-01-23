    public void ObserveSeat(object state, Barrier barrier)
    {
      barrier.AddParticipant();
      try
      {
        for (int i = 0; i < NUM_ITERATIONS; i++)
        {
          if (i % AMOUNT == 0)
          {
            // Let the other threads know we are done with this phase and wait
            // for them to catch up.
            barrier.SignalAndWait();
          }
          // Perform your work here.
        }
      }
      finally
      {
        barrier.RemoveParticipant();
      }
    }
