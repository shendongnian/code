      /// <summary>
     /// Create the Model class list iterating through the tables
    /// </summary>
    /// <param name="dr">Sql Data reader for the database schema</param>
        private void CreateModelClassFiles(SqlDataReader dr)
        {
         if (dr != null)
        {
        string lstrOldTableName = string.Empty;
        StreamWriter sw = null;
        System.Text.StringBuilder sb = null;
        System.Text.StringBuilder sbAttr = null;
        while(dr.Read())
        {
          string lstrTableName = dr.GetString(0);
          string lstrAttributeName = dr.GetString(1);
          string lstrAttributeType = GetSystemType(dr.GetString(2));
          if (lstrOldTableName != lstrTableName)
          {
            if (sw != null)
            {
              this.CreateClassBottom(sw, sb.ToString().TrimEnd(
                         new char[]{',', ' ', '\r', '\t', '\n'}),
                         sbAttr.ToString());
                sw.Close();
            }
            sb = new System.Text.StringBuilder(lstrTableName);
            sb.Append(".cs");
            FileInfo lobjFileInfo = new FileInfo(sb.ToString());
            sw = lobjFileInfo.CreateText();
            this.CreateClassTop(sw, lstrTableName);
            sb = new System.Text.StringBuilder("\r\n\t/// \r\n\t" + 
                 "/// User defined Contructor\r\n\t/// \r\n\tpublic ");
            sbAttr = new System.Text.StringBuilder();
            sb.Append(lstrTableName);
            sb.Append("(");
          }
          else
          {
            this.CreateClassBody(sw, lstrAttributeType, lstrAttributeName);
            sb.AppendFormat("{0} {1}, \r\n\t\t", 
               new object[]{lstrAttributeType, lstrAttributeName});
            sbAttr.AppendFormat("\r\n\t\tthis._{0} = {0};", 
               new object[]{lstrAttributeName});
          }
          lstrOldTableName = lstrTableName;
          this.progressBarMain.Increment(1); 
        }
        MessageBox.Show("Done !!");
      }
    }
