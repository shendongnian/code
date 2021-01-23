    var query =
        from t1 in myTABLE1List // List<TABLE_1>
        join t2 in myTABLE1List
          on new { A = t1.ColumnA, B = t1.ColumnB } equals new { A = t2.ColumnA, B = t2.ColumnB }
        join t3 in myTABLE1List
          on new { A = t2.ColumnA, B =  t2.ColumnB } equals new { A = t3.ColumnA, B = t3.ColumnB }
        ...
