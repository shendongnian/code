            if (dt!=null)
            {
               if(dt.rows.count> 0)
               {
                  st = dt.Rows[3]["timeslot_StartTime"].ToString();
               }
            }
            DateTime dt = DateTime.MinValue;
            if (DateTime.TryParse(st, out dt))
            {
                //was successful and do something here
            }
