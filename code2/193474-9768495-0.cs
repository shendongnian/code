    private void HandleBindingSourceCurrentChanged(object _sender, EventArgs _e)
    {
        if(m_bindingSource.Count == 0) // You also can check position == -1
        {
          m_bindingSource.ResetBindings(false);
        }
        btnRemove.Enabled = (m_bindingSource.Current != null);
    }
