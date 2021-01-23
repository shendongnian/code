        foreach ( DataRow row in dt.Rows )
                {
                    string name = row.ItemArray.GetValue ( 2 ).ToString ( ).ToUpper().Trim();
                    if ( name == "IP" )
                    {
                        row.BeginEdit();
                        row [ "grd" ] = "-";
                        row.EndEdit();
                    }
                }
