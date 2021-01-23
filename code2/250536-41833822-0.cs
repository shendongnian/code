      public static void sortOutputTable(ref DataTable output)
            {
                DataView dv = output.DefaultView;
                dv.Sort = "specialCode ASC, otherCode DESC";
                DataTable sortedDT = dv.ToTable();
                output = sortedDT;
            }
