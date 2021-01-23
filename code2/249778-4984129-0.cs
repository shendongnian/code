    private SectionData _selectedSection;
    public SectionData SelectedSection
    {
        get { return _selectedSection; }
        set 
        {
            _selectedSection = value;
            if (_selectedSection != null) SelectedLine = _selectedSection.Line;
        }
    }
