                    UtcNow = Convert.ToDateTime(UtcNowtxt.Text.Trim());
                    LastEdited = Convert.ToDateTime(LastEditedtxt.Text.Trim());
                    TimeSpan GetDiff = (LastEditedtxt).Subtract(UtcNow);
                    if (GetDiff.Minutes < 30)
                    {
                        //Do something
                    }
