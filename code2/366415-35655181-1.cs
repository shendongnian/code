    private void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        // This actually works with this approach
        string text = $"[Line: {e.Exception?.LineNumber}, Column: {e.Exception?.LinePosition}]: {e.Message}";
        switch (e.Severity) {
            case XmlSeverityType.Error:
                Logger.Error(text);
                break;
            case XmlSeverityType.Warning:
                Logger.Warn(e.Message);
                break;
        }
    }
