cs
for (int i = csvData.Columns.Count - 1; i >= 0; i--)
{
   DataColumn dc = csvData.Columns[i];
   if (dc.ColumnName.Contains("Column"))
   {
       csvData.Columns.Remove(dc);
   }
}
