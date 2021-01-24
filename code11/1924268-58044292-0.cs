    private string _SelectedValue;
    public string SelectedValue
    {
        get => _SelectedValue;
        set
        {
            _SelectedValue = value;
            foreach (var item in MyObColl.ToList()) item.ChosenValue = _SelectedValue;
        }
    }
