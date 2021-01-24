DataTable dtDaily = new DataTable();
// If you want to compare the Time, use TimeSpan
TimeSpan time1 = new TimeSpan(8, 0, 0);
foreach (DataRow pRow in dtDaily.Rows)
{
   if (pRow.Field<DateTime>("STATUSIN").TimeOfDay > time1)
   {
      // This will ONLY be the time portion.. not the full datetime. Notice the 
      // parenthesis around the the statement on the right. You want to convert the resulting
      // Time (after subtraction) to string.
      pRow["LATECOME"] = (pRow.Field<DateTime>("STATUSIN").TimeOfDay  - time1).ToString();
   }
}
`pRow.Field<DateTime>("field)` takes the string representation of the data and converts it to DateTime. This is similar to `DateTime.Parse(pRow["field"])` but takes away the step of doing the conversions.
