        #region AutoComplete Organization Box
        System.Windows.Forms.Timer mOrganizationTextChangedTimer = null;
        void organizationComboBox_TextChanged(object sender, System.EventArgs e)
        {
            if (mOrganizationTextChangedTimer == null)
            {
                mOrganizationTextChangedTimer = new System.Windows.Forms.Timer();
                mOrganizationTextChangedTimer.Interval = 500;
                mOrganizationTextChangedTimer.Tick += new EventHandler(mOrganizationTextChangedTimer_Tick);
            }
            mOrganizationTextChangedTimer.Enabled = true;
        }
        void mOrganizationTextChangedTimer_Tick(object sender, EventArgs e)
        {
            mOrganizationTextChangedTimer.Enabled = false;
            UpdateOrganizationNameAutocompleteResults( comboBoxOrganizationName.Text );    
        }
        void UpdateOrganizationNameAutocompleteResults( string pSearchString ) 
        {
            listBoxOrganizationAutocompleteResults.Items.Clear();
            if (comboBoxOrganizationName.Text.Length == 0)
            {
                HideOrganizationNameAutocompleteResults();
                return;
            }
            
            // Added a custom query to search our database and return results that match.  The query uses UCase on the columns.
            allertDataSet3.OrganizationDataTable orgs = organizationTableAdapter.GetDataByOrganizationNameSearchUCase("%" + pSearchString.ToUpper() + "%", "%" + pSearchString.ToUpper() + "%");
            
            foreach( allertDataSet3.OrganizationRow r in orgs ) {
                string longName = r.OrganizationName;
                listBoxOrganizationAutocompleteResults.Items.Add(longName);
                listBoxOrganizationAutocompleteResults.Visible = true;
                listBoxOrganizationAutocompleteResults.BringToFront();
            }
            // This Code block is needed because once you select an organization, the combobox text changes which forces another search.
            // There is only one result from that search so this hides it when the search result equals the already selected combobox.
            try {
                System.Data.DataRowView drv = (System.Data.DataRowView) comboBoxOrganizationName.SelectedItem;
                allertDataSet3.OrganizationRow orgRow = (allertDataSet3.OrganizationRow)drv.Row;
                
                if ( listBoxOrganizationAutocompleteResults.Items.Count == 1 && 
                    ((string)listBoxOrganizationAutocompleteResults.Items[0]).Equals(orgRow.OrganizationName) )
                {
                    HideOrganizationNameAutocompleteResults();
                }
            }
            catch {
                // do nothing
            }            
        }
        void organizationComboBoxAutocompleteResults_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            foreach (System.Data.DataRowView drv in comboBoxOrganizationName.Items)
            {
                Alertus.Allert.allertDataSet3.OrganizationRow orgRow = (Alertus.Allert.allertDataSet3.OrganizationRow)drv.Row;
                if (orgRow.OrganizationName.Equals((string) listBoxOrganizationAutocompleteResults.SelectedItem))
                {
                    // Prevents it from searching again.
                    comboBoxOrganizationName.TextChanged -= organizationComboBox_TextChanged;
                    comboBoxOrganizationName.SelectedItem = drv;
                    comboBoxOrganizationName.TextChanged += organizationComboBox_TextChanged;
                    HideOrganizationNameAutocompleteResults();
                    return;
                }
            }
            // This is basically an error... it should have found it.
            HideOrganizationNameAutocompleteResults();
        }
        void listBoxOrganizationAutocompleteResults_LostFocus(object sender, System.EventArgs e)
        {
            HideOrganizationNameAutocompleteResults();
        }
        void HideOrganizationNameAutocompleteResults()
        {
            listBoxOrganizationAutocompleteResults.Visible = false;
        }
        private void listBoxOrganizationAutocompleteResults_MouseClick(object sender, MouseEventArgs e)
        {
            // When mouse is clicked we assume user made a seletion.
            organizationComboBoxAutocompleteResults_SelectedIndexChanged(null, null);
        }
        /// <summary>
        /// Redirects the Arrow keys to update the selected index in the autocomplete list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxOrganizationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (listBoxOrganizationAutocompleteResults.Items.Count >= 1 && listBoxOrganizationAutocompleteResults.Visible)
                {
                    if (listBoxOrganizationAutocompleteResults.SelectedIndex < 0)
                    {
                        listBoxOrganizationAutocompleteResults.SelectedIndex = 0;
                    }
                    else
                    {
                        listBoxOrganizationAutocompleteResults.SelectedIndex = (listBoxOrganizationAutocompleteResults.SelectedIndex - 1) % listBoxOrganizationAutocompleteResults.Items.Count;
                    }
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (listBoxOrganizationAutocompleteResults.Items.Count >= 1 && listBoxOrganizationAutocompleteResults.Visible )
                {
                    if (listBoxOrganizationAutocompleteResults.SelectedIndex < 0)
                    {
                        listBoxOrganizationAutocompleteResults.SelectedIndex = 0;
                    }
                    else
                    {
                        listBoxOrganizationAutocompleteResults.SelectedIndex = (listBoxOrganizationAutocompleteResults.SelectedIndex + 1) % listBoxOrganizationAutocompleteResults.Items.Count;
                    }
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (listBoxOrganizationAutocompleteResults.Visible)
                {
                    organizationComboBoxAutocompleteResults_SelectedIndexChanged(null, null);
                }
            }
        }
        #endregion
