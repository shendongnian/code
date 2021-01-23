    foreach (Google.GData.Calendar.EventEntry ev in calFeed.Entries)
            {
                ExtensionCollection<When> v = ev.Times;
                DataRow dr = dt.NewRow();
    
                dr["title"] = ev.Title.Text;
                dr["url"] = ev.Content.Content;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
