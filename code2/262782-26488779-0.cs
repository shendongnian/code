    var query =
        from t1 in myTABLE1List 
        join t2 in myTABLE1List
          on new { ColA=t1.ColumnA, ColB=t1.ColumnB } equals new { ColA=t2.ColumnA, ColB=t2.ColumnB }
        join t3 in myTABLE1List
          on new {ColC=t2.ColumnA, ColD=t2.ColumnB } equals new { ColC=t3.ColumnA, ColD=t3.ColumnB }
