    cmd1.Parameters.Add["@InsertDate"].Value = textBox1.Text.AsDBDateTime();
    // ...
    public static class DBValueExtensions {
        public static object AsDBDateTime(this string s) {
            object dateTimeValue;
            var str = s;
            if ( null != str ) { str = str.Trim(); }
            if ( string.IsNullOrEmpty(str) ) {
                dateTimeValue = DBNull.Value;
            }
            else {
                dateTimeValue = DateTime.Parse(str);
            }
    
            return dateTimeValue;
    }
