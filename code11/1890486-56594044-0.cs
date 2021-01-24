 csharp
internal static void DataView GetSortedView(this DataTable table)
{
   //create another column for an index
   string tempSortName = "[TEMP_SORT]";
   table.Columns.Add(tempSortName);
   //sort columns by Name for example
   var enumerable= table.AsEnumerable().OrderBy(field => field.Field<string>("Name"), new NaturalStringComparer());
   //set the temporary order (index)
   int count = 0;
   foreach(DataRow row in enumerable)
   {
       row[tempSortName] = count++;
   }
   //here is the tricky part
   int half = table.Rows.Count / 2;
   enumerable= enumerable.OrderBy(row =>
    {
      if (int.TryParse(row[tempSortName]?.ToString(), out int myIndex )) //everything here is triggered if row[tempSortName] is set... or before it is set... idk... wtf. so there is a new column but there are not any indices in it (or just one)
       {
         myIndex++;
         bool upperHalf = myIndex  > half;
         if (upperHalf)
         {
            myIndex  -= half;
         }
         return new CustomSortItem(myIndex , upperHalf);
       }
    }, new CustomSort());
   DataView view = enumerable.AsDataView();
   view.Table.Columns.Remove(tempSortName);
   return view;
}
internal static IEnumerable<DataRow> GetSortedTable(this DataTable table)
{
   IEnumerable<DataRow> result;
   //sort columns by Name for example
   var enumerable= table.AsEnumerable().OrderBy(field => field.Field<string>("Name"), new NaturalStringComparer());
   int half =  table.Rows.Count / 2;
   IEnumerable<DataRow> one = enumerable.Take(half);
   IEnumerable<DataRow> two = enumerable.Skip(half);
   result = one.InterleaveEnumerationsOfEqualLength(two);
   return result;
 }
internal static IEnumerable<DataRow> InterleaveEnumerationsOfEqualLength<DataRow>(this IEnumerable<DataRow> first, IEnumerable<DataRow> second)
{
   using (IEnumerator<DataRow> enumerator1 = first.GetEnumerator(), enumerator2 = second.GetEnumerator())
   {
      while (enumerator1.MoveNext() && enumerator2.MoveNext())
      {
         yield return enumerator1.Current;
         yield return enumerator2.Current;
      }
    }
}
