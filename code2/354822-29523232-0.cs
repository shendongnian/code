            if (oDate is DBNull)
            {
                return "";
            }
            else
            {
                DateTime dDate = Convert.ToDateTime(oDate);
                string sDate = dDate.ToShortDateString();
                return sDate;
            }
           
        }
