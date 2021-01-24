       private int RowIndexFromButton() {
         var checkedRadioButton = groupUrl
           .Controls
           .OfType<RadioButton>()
           .FirstOrDefault(x => x.Checked);
 
         if (checkedRadioButton == null)
           return -1;
         
         switch (checkedRadioButton.Text) { 
           case "MK-Live":
             return 1;
           case "MK-Test":
             return 2;
           case "Roland Test":
             return 3;
           default:
             return 0;
         }
       }
       private static IEnumerable<T> RowFromArray<T>(T[,] array, int row) {
         if (null == array)
           throw new ArgumentNullException(nameof(array));
         else if (row < array.GetLowerBound(0) || row > array.GetUpperBound(0))
           yield break;
         for (int i = array.GetLowerBound(1); i <= array.GetUpperBound(1); ++i)
           yield return array[row, i];
       }
