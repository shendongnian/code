     private void UpdateFilter()
        {
            // Continue only if the selection has changed.
            if (dropDownListBox.SelectedItem.ToString().Equals(selectedFilterValue))
            {
                return;
            }
            // Store the new selection value. 
            selectedFilterValue = dropDownListBox.SelectedItem.ToString();
            // Cast the data source to an IBindingListView.
            IBindingListView data = 
                this.DataGridView.DataSource as IBindingListView;
            Debug.Assert(data != null && data.SupportsFiltering,
                "DataSource is not an IBindingListView or does not support filtering");
            // If the user selection is (All), remove any filter currently 
            // in effect for the column. 
            if (selectedFilterValue.Equals("(All)"))
            {
                data.Filter = FilterWithoutCurrentColumn(data.Filter);
                filtered = false;
                currentColumnFilter = String.Empty;
                return;
            }
            // Declare a variable to store the filter string for this column.
            String newColumnFilter = null;
            // Store the column name in a form acceptable to the Filter property, 
            // using a backslash to escape any closing square brackets. 
            String columnProperty = 
                OwningColumn.DataPropertyName.Replace("]", @"\]");
            // Determine the column filter string based on the user selection.
            // For (Blanks) and (NonBlanks), the filter string determines whether
            // the column value is null or an empty string. Otherwise, the filter
            // string determines whether the column value is the selected value. 
            switch (selectedFilterValue)
            {
                case "(Blanks)":
                    newColumnFilter = String.Format(
                        "LEN(ISNULL(CONVERT([{0}],'System.String'),''))=0",
                        columnProperty);
                    break;
                case "(NonBlanks)":
                    newColumnFilter = String.Format(
                        "LEN(ISNULL(CONVERT([{0}],'System.String'),''))>0",
                        columnProperty);
                    break;
                default:
                    newColumnFilter = String.Format("[{0}]='{1}'",
                        columnProperty,
                        ((String)filters[selectedFilterValue])
                        .Replace("'", "''"));  
                    break;
            }
            // Determine the new filter string by removing the previous column 
            // filter string from the BindingSource.Filter value, then appending 
            // the new column filter string, using " AND " as appropriate. 
            String newFilter = FilterWithoutCurrentColumn(data.Filter);
            if (String.IsNullOrEmpty(newFilter))
            {
                newFilter += newColumnFilter;
            }
            else
            {
                newFilter += " AND " + newColumnFilter;
            }
            // Set the filter to the new value.
            try
            {
                data.Filter = newFilter;
            }
            catch (InvalidExpressionException ex)
            {
                throw new NotSupportedException(
                    "Invalid expression: " + newFilter, ex);
            }
            // Indicate that the column is currently filtered
            // and store the new column filter for use by subsequent
            // calls to the FilterWithoutCurrentColumn method. 
            filtered = true;
            currentColumnFilter = newColumnFilter;
        }
