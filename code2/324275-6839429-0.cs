    public static DataTable DataTableCommaReplce(DataTable dt) {
        foreach (DataRow row in dt.Rows) {
            foreach (DataColumn col in dt.Columns) {
                string s = row[col] as string;
                if (s != null) {
                    if (s.Contains(',')) {
                        row[col] = string.Format("\"{0}\"", s);
                    }
                }
             }
        }
        return dt;
    }
