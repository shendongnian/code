    private void HandleRemoveClick(object _sender, EventArgs _e)
    {
        btnRemove.Enabled = false;
        m_bindingSource.RemoveCurrent();
    }
    private void HandleBindingSourceCurrentChanged(object _sender, EventArgs _e)
    {
        if(m_bindingSource.Current != null)
            btnRemove.Enabled = true;
    }
