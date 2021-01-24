    static class MethodLibrary //Method does not return something
    {
	    public static void Fill_cmbDay(ComboBox strYear, int Month, ComboBox  cmbTarget) //Void used does not return something
        {
            //Find how many days month has based on selected year & month. Convert month name to month number.
            int days = DateTime.DaysInMonth(Convert.ToInt32(strYear.SelectedItem),Month);
        //Clear Combo box
        cmbTarget.Items.Clear();
            //Loop from 1 to number of days & add items to combo box
            for (int i = 1; i <= days; i++)
            {
                cmbTarget.Items.Add(i);
            }
        }
    }
