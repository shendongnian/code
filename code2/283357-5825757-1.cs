                if ((DateTime.Now.DayOfWeek == DayOfWeek.Friday && DateTime.Now.Hour >= 17) || 
                    DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                {
                    Response.Redirect("ApplicationDown.aspx");
                }
