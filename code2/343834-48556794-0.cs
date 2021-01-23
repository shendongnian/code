            int c = 0; ;
            DataTable dtx = (DataTable)cmbCd.DataSource;
            if (dtx != null)
            {
                foreach (DataRow dx in dtx.Rows)
                {
                    if (dx[cmbCd.ValueMember.ToString()].ToString() == text)
                        return c;
                    c++;
                }
                return -1;
            }else
                return -1;
        } 
