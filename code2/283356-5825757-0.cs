                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday || 
                    DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                {
                    Response.Redirect("ApplicationDown.aspx");
                }
