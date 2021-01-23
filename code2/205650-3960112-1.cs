    void m_lookUpEdit_Properties_Validating(object sender, CancelEventArgs e)
    {
        if (string.IsNullOrEmpty(m_lookUpEdit.Text))
        {
            m_lookUpEdit.EditValue = null;
        }
    }
