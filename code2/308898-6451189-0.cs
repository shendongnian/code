    try
    {
        if (MyDataSets.Current.HasChanges() && !MyDataSets.Current.Name.Equals(cbChosenDataSet.Value))
        {
            cbChosenDataSet.DropDownStyle = ComboBoxStyle.DropDown;
            cbChosenDataSet.Text = MyDataSets.Current.Name + ' ';
            Application.DoEvents();
        }
        else return;
        /*
         * UserChoseToCancel is set according to user's choice
         */
        if (UserChoseToCancel)
            cbChosenDataSet.Value = MyDataSets.Current.Name;
        else
            MyDataSets.SetCurrent(cbChosenDataSet.Value);
        /*
         * other things
         */
    }
    catch(Exception e) {/* handling */}
    finally
    {
        cbChosenDataSet.DropDownStyle = ComboBoxStyle.DropDownList;
    }
