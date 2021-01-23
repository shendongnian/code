    foreach (DataRow dr in ds.Tables[0].Rows)
    {
         String StartCourse = dr[0].ToString();
         string EndCourse = dr[1].ToString();
         DateTime SystemTime = Convert.ToDateTime(DateTime.Now);
         DateTime StartTime = Convert.ToDateTime(StartCourse);
         DateTime EndTime = Convert.ToDateTime(EndCourse);
    
         if (StartTime.TimeOfDay.Ticks <= SystemTime.TimeOfDay.Ticks && SystemTime.TimeOfDay.Ticks < EndTime.TimeOfDay.Ticks)
         {
               ds.Tables[0].Rows[count][5] = "ok";
         }
    
         else
         {
               ds.Tables[0].Rows[count][5] = "nok";
         }
    
         count++;
         //dataGridView1.DataSource = ds.Tables[0];   <- HERE COULD BE THE PROBLEM
}
