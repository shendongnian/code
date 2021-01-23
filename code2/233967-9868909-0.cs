    public decimal codes(string subs)
        {
            decimal a = 0;
            con_4code();
                query = "select SUBJINTN.[SCODE] from SUBJINTN where SUBJINTN.[ABBR] = '" +                         subs.ToString() + "'";
                cmd1 = new OleDbCommand(query, concode);
                OleDbDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    a = dr.GetDecimal(0);
                    MessageBox.Show(a.ToString());
                }
                return a;
                    
            
            
        }
