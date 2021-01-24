    DateTime _lastUpdated = DateTime.MinValue;
    void UpdateStatusLabel(string text)
    {
        if(DateTime.Now > _lastUpdate)
        {
            ToolStripStatusLabel.Text = text;
            _lastUpdate = DateTime.Now + TimeSpan.FromSeconds(1);
        }
    }
