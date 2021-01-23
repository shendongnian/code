    int sum = 0;
    foreach (DataRow dr in dt.Rows)
    {
         dynamic value = dr[index].ToString();
         if (!string.IsNullOrEmpty(value))
         { 
             sum += Convert.ToInt32(value);
         }
    }
