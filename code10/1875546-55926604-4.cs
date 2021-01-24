               for (int i = 1; i < 5; i++)
                {
                    if (countnumM > 0) // this is == 0
                    {
                        float levelPercM = Convert.ToInt32(tab2table.Compute("COUNT(MLevel)", "MLevel =" + i.ToString()));
                        tab2tableExtra.Rows[i - 1][1] = Math.Round(100 * levelPercM / countnumM, 2);
                    }
                    else               // This is what's happening
                        tab2tableExtra.Rows[i - 1][1] = null;
                    if (countnumRW > 0) // this is == 0
                    {
                        decimal levelPercRW = Convert.ToDecimal(tab2table.Compute("COUNT([RLevel])", "RLevel =" + i.ToString()));
                        tab2tableExtra.Rows[i - 1][2] = Math.Round(100 * levelPercRW / countnumRW, 2);
                    }
                    else                // This is what's happening
                        tab2tableExtra.Rows[i - 1][2] = null;
                } 
