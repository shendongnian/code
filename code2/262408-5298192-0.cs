    using (DataAdaptor adaptor = new DataAdaptor("SELECT * FROM table", connection)) {
        using (CommandBuilder builder = new CommandBuilder(adaptor)) {
            adaptor.Update(m_DataTable);
        }
    }
    
    m_DataTable.AcceptChanges();
