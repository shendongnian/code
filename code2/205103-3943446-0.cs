    public void DataRefresh(string comboBoxPropertyName, object value) {
        var query = from s in searchResults
                    where (s.GetType().GetProperties()[comboBoxPropertyName].GetValue(s) = value)
                    select s
        SearchDataBindingSource.DataSource = query.ToList();
    }
