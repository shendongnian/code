    private bool CasesFunction(ListBox lbItem, List<int> validIndices)
    {
         for (int index = 0; index < lbItem.Items.Count; index++)
         {
            if (lbItem.SelectedIndices.Contains(index) && !validIndices.Contains(index))
               return false;
         }
         return true;
    }
