    private void PopulateListView(IEnumerable<FontFamily> fontFamilies)
    {
        try
        {
            m_listView.BeginUpdate();
            float fontSize = m_listView.Font.Size;
            Color foreColor = m_listView.ForeColor;
            Color backColor = m_listView.BackColor;
            string sampleText = m_sampleText;
            foreach (FontFamily fontFamily in fontFamilies)
            {
                var listViewItem = new ListViewItem(fontFamily.Name)
                {
                    UseItemStyleForSubItems = false
                };
                var sampleSubItem = new ListViewItem.ListViewSubItem(listViewItem, sampleText, foreColor, backColor, new Font(fontFamily, fontSize));
                listViewItem.SubItems.Add(sampleSubItem);
                m_listView.Items.Add(listViewItem);
            }
        }
        finally
        {
            m_listView.EndUpdate();
        }
    }
