          DataSet s = new DataSet ();
          DataTable t1 = new DataTable ();
          t1.Columns.Add ("A", typeof (int));
          t1.Columns.Add ("B", typeof (string));
          s.Tables.Add (t1);
          t1.Rows.Add (1, "T1");
          t1.Rows.Add (2, "T1");
          DataTable t2 = new DataTable ();
          t2.Columns.Add ("A", typeof (int));
          t2.Columns.Add ("B", typeof (string));
          s.Tables.Add (t2);
          t2.Rows.Add (1, "T2");
          t2.Rows.Add (2, "T2");
          t2.Rows.Add (3, "T2");
          var result = from t in s.Tables.OfType<DataTable> ()
                       from r in t.Rows.OfType<DataRow> ()
                       select r;
