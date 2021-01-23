    public static MySqlDataContext mysql = new MySqlDataContext();
    public static SQLDataContext sql = new SQLDataContext();
    public static void Main() {
      var qA = mysql.tableA.ToList();
      var qB = sql.TableBs.ToList();
      var rows = from a in qA
                 join b in qB on a.col equals b.col
                 select a;
      foreach(var row in rows) {
          ...
      }
    }
