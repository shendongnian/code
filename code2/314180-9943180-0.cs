            // now populate the calendar
            while (calFeed != null && calFeed.Entries.Count > 0)
            {
                // look for the one with dinner time...
                foreach (EventEntry entry in calFeed.Entries)
                {
                    this.entryList.Add(entry); 
                    if (entry.Times.Count > 0)
                    {
                        foreach (When w in entry.Times) 
                        {
                            dates.Add(w.StartTime); 
                        }
                    }
                }
                // just query the same query again.
                if (calFeed.NextChunk != null)
                {
                    query.Uri = new Uri(calFeed.NextChunk); 
                    calFeed = service.Query(query) as EventFeed;
                }
                else
                    calFeed = null;
            }
