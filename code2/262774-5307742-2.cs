    var query =
        from t1 in myTABLE1List // List<TABLE_1>
        join t2 in myTABLE1List
          on new { t1.ColumnA, t1.ColumnB } equals new { t2.ColumnA, t2.ColumnB }
        join t3 in myTABLE1List
          on new { t2.ColumnA, t2.ColumnB } equals new { t3.ColumnA, t3.ColumnB }
        ...
