        private void bsDataPages_CurrentChanged(object sender, EventArgs e)
        {
            PageList list = bsDataPages.DataSource as PageList;
            PageList.ItemPage page = bsDataPages.Current as PageList.ItemPage;
            var items = m_datastore.GetTableItems(m_conn, 
                list.TableName,page.Limit,page.Offset);
        }
