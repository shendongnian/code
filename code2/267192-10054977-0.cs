            EventLog ev = new EventLog()
            {
                Log = "System"
            };
            SystemSession sess;
            DateTime t1 = DateTime.Now;
            DateTime t2 = DateTime.Now;
            DateTime fromDate = DateTime.Now.AddDays(-30);
            TimeSpan t;
            int i, j=0;
            t1 = DateTime.Now;
            for (i = ev.Entries.Count - 1; i >= 0; i--)
            {
                if (ev.Entries[i].TimeGenerated < fromDate) break;
                if (ev.Entries[i].InstanceId == 12)
                {
                    //do something ...
                    break;
                }
            }
            t2 = DateTime.Now;
            t = new TimeSpan(t2.Ticks - t1.Ticks);
            string duration = String.Format("After {0} iterations, elapsed time = {2}",
                ev.Entries.Count - i,
                t.ToString("c"));
