    foreach (Google.GData.Calendar.EventEntry ev in calFeed.Entries)
        {
            CalendarEvents ce = new CalendarEvents();
            ce.Title = ev.Title.Text;
            ExtensionCollection<When> v = ev.Times;
            ce.Date = v[0].StartTime;
            ce.Content = ev.Content.Content;
        }
