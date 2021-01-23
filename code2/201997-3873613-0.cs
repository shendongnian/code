      static void Main(string[] args)
      {
          DataTable t = getStuff("test");
          var xml = new XElement("Main", from row in t.AsEnumerable()
                    select new XElement("firstlevel",
                        new XAttribute("a", row["a"]),
                        new XAttribute("b", row["b"]),
                        from row2 in getStuff(row["a"].ToString()).AsEnumerable()
                        select new XElement("secondlevel",
                           new XAttribute("a", row2["a"]),
                           new XAttribute("b", row2["b"]),
                           from row3 in getStuff(row2["a"].ToString()).AsEnumerable()
                           select new XElement("thirdlevel",
                               new XElement("a", row3["a"]),
                               new XElement("b", row3["b"])))));
          Console.WriteLine(xml.ToString());
      }
      private static DataTable getStuff(string s)
      {
          Random r=new Random(s.GetHashCode());
          DataTable t = new DataTable();
          t.Columns.Add("a");
          t.Columns.Add("b");
          for (int i = 0; i < 2; i++)
          {
              t.Rows.Add (r.Next().ToString(), r.Next().ToString());
          }
          return t;
      }
