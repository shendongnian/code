        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e != null)
            {
                int nLength = e.Item.Text.IndexOf("(") - 1;
                string strReport = nLength <= 0 ? e.Item.Text : e.Item.Text.Substring(0, nLength);
                if (e.Item.Checked)
                {
                    _lstReportFilter.Add(strReport);
                }
                else
                {
                    _lstReportFilter.Remove(strReport);
                }
            }
            List<string> checkBoxReportFilter = new List<string>();
            foreach (ReportRecord obj in this._lstReportRecords)
            {
                foreach (string str in _lstReportFilter)
                {
                    if (str.ToLower().Contains(obj.Description.ToLower()))
                    {
                        checkBoxReportFilter.Add(obj.PartID.ToString());
                    }
                }
            }
            try
            {
                if (checkBoxReportFilter.Count == 0 && listView1.CheckedItems.Count > 0)
                {
                    throw new NullReferenceException();
                }
                _strReportFilter = String.Join(",", checkBoxReportFilter.ToArray());
            }
            catch (NullReferenceException)
            {
                _strReportFilter = "-1";
            }
            if (!bShowAll)
            {
                generateReport();
            }
        }
        private void ShowAllErrorReports_CheckChanged(object sender, EventArgs e)
        {
            bShowAll = true;
            foreach (ListViewItem lvi in listView1.Items)
            {
                lvi.Checked = ((CheckBox)sender).Checked;
            }
            _lstReportFilter.Clear();
            bShowAll = false;
            generateReport();
        }
        private void ShowTaggedRecords_CheckChanged(object sender, EventArgs e)
        {
            bool bChecked = ((CheckBox)sender).Checked;
            if (bChecked)
            {
                if (!_lstReportFilter.Contains("Show Tagged Records"))
                {
                    _lstReportFilter.Add("Show Tagged Records");
                }
            }
            else
            {
                _lstReportFilter.Remove("Show Tagged Records");
            }
            listView_ItemChecked(null, null);
        }
