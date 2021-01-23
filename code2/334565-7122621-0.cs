    /// <summary>
    /// Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="dataGridViewWantsInputKey"></param>
    /// <returns></returns>
    public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
    {
        // Let the custom edit control handle the keys listed.
        switch (key & Keys.KeyCode)
        {
            case Keys.Escape:
                return true;
            default:
                return !dataGridViewWantsInputKey;
        }
    }
