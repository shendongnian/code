            ArrayList check = new ArrayList();            
            for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
            {
                int iValue = Convert.ToInt32(oDS.Tables[0].Rows[i][3].ToString());
                check.Add(iValue);
            }
