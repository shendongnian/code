    bool foundOne = false;
    foreach (EventLogEntry entry in log.Entries)
        {
            if (entry.Message.ToUpper().Contains(logValue))
            {
              foundOne = true;
            }
        }
    Assert(foundOne);
