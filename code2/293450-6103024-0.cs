            this.listBoxResults.SelectedIndex = this.listBoxResults.Items.Add("Clearing previous calender entries");
            
            String calendarURI = calendarEntry.Id.Uri.ToString();
            //The last part of the calendarURI contains the calendarID we're looking for
            String calendarID = calendarURI.Substring(calendarURI.LastIndexOf("/")+1);
            EventQuery query = new EventQuery();
            query.Uri = new Uri("http://www.google.com/calendar/feeds/" + calendarID + "/private/full");
            EventFeed eventEntries = calendarService.Query(query);
            AtomFeed batchFeed = new AtomFeed(eventEntries);
            foreach (AtomEntry entry in eventEntries.Entries)
            {
                entry.Id = new AtomId(entry.EditUri.ToString());
                entry.BatchData = new GDataBatchEntryData(GDataBatchOperationType.delete);
                batchFeed.Entries.Add(entry);
            }
            EventFeed batchResultFeed = (EventFeed)calendarService.Batch(batchFeed, new Uri(eventEntries.Batch));
            //check the return values of the batch operations to make sure they all worked.
            //the insert operation should return a 201 and the rest should return 200
            bool success = true;
            foreach (EventEntry entry in batchResultFeed.Entries)
            {
                if (entry.BatchData.Status.Code != 200 && entry.BatchData.Status.Code != 201)
                {
                    success = false;
                    listBoxResults.SelectedIndex = listBoxResults.Items.Add("The batch operation for " +
                        entry.Title.Text + " failed.");
                }
            }
            if (success)
            {
                listBoxResults.SelectedIndex = listBoxResults.Items.Add("Calendar event clearing successful!");
            }
        }
