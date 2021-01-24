    public DataTable getMatchedColumnAndValue(DataTable dt1, DataTable dt2)
    {
       try
       {
          var ndt = new DataTable();
          //creating columns for the table
          var dt1columns = dt1.Columns.Cast<DataColumn>().Select(s => s.ColumnName).ToList();
          var dt2columns = dt2.Columns.Cast<DataColumn>().Select(s => s.ColumnName).ToList();
          var MatchedCol = dt1columns.Intersect(dt2columns).ToList();
          foreach (var col in MatchedCol)
          {
             ndt.Columns.Add(col);
          }
          //creating columsn matcehd row
          var drnew = new string[MatchedCol.Count];
          for (int i = 0; i < MatchedCol.Count; i++)
          {
             if (dt1.Rows[0][MatchedCol[i]].ToString() == dt2.Rows[0][MatchedCol[i]].ToString())
                  drnew[i] = dt1.Rows[0][MatchedCol[i]].ToString();
             else
                  drnew[i] = null;
          }
          ndt.Rows.Add(drnew);
          //removing null value columns
          foreach (var col in MatchedCol)
          {
             if (ndt.AsEnumerable().All(dr => dr.IsNull(col)))
                 ndt.Columns.Remove(col);
          }
                
          return ndt;
        }
        catch (Exception ex)
        {
           throw ex;
        }
    }
