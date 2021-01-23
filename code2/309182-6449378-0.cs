                    StringBuilder rv = new StringBuilder();
                    TimeSpan ts = DateTime.Now - lastCommunicationDateTime;
                    if (ts.TotalDays >= 1.0)
                    {
                        rv.AppendFormat("{0} days, {1} hours ago", (int)ts.TotalDays, ts.Hours);
                    }
                    else if (ts.TotalHours > 1.0)
                    {
                        rv.AppendFormat("{0} hours, {1} minutes ago", (int)ts.TotalHours, ts.Minutes);
                    }
                    else if (ts.TotalMinutes > 1.0)
                    {
                        rv.AppendFormat("{0} minutes, {1} seconds ago", (int)ts.TotalMinutes, ts.Seconds);
                    }
                    else
                    {
                        rv.AppendFormat("{0} seconds ago", (int)ts.TotalSeconds);
                    }
                    return rv.ToString();
