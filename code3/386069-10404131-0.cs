    DataTable copyTable = Table.Copy();
    Table.Clear();
    for( int i = 0; i < copyTable.Rows.Count; i++ )
     {
          DataRow r = copyTable.Rows[i];
          r[0] = i;
          Table.ImportRow( r );
     }
