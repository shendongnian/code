               string oldVoltage = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tension = (string)dt.Rows[i]["Tension"];
                    if (tension == oldVoltage)
                    {
                        dt.Rows[i]["Tension"] = string.Empty;
                    }
                    else
                    {
                        oldVoltage = tension;
                    }
                }
