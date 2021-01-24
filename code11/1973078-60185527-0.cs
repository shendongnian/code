    private void OKButton_Click(object sender, EventArgs e)
	{
	    try
	    {
	        if (!_dirty || !CollectionEditable)
	        {
	            _dirty = false;
	            DialogResult = DialogResult.Cancel;
	            return;
	        }
	        if (_dirty)
	        {
	            object[] items = new object[_listbox.Items.Count];
	            for (int i = 0; i < items.Length; i++)
	            {
	                items[i] = ((ListItem)_listbox.Items[i]).Value;
	            }
	            Items = items;
	        }
	        if (_removedItems != null && _dirty)
	        {
	            object[] deadItems = _removedItems.ToArray();
	            for (int i = 0; i < deadItems.Length; i++)
	            {
	                DestroyInstance(deadItems[i]);
	            }
	            _removedItems.Clear();
	        }
	        _createdItems?.Clear();
	        _originalItems?.Clear();
	        _listbox.Items.Clear();
	        _dirty = false;
	    }
	    catch (Exception ex)
	    {
	        DialogResult = DialogResult.None;
	        DisplayError(ex);
	    }
	}
