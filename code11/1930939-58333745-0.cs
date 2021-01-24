    public EvidenceDTO MyEvidence
    {
        get
        {
            if (_myEvidence == null)
            {
                _myEvidence = new EvidenceDTO();
            }
            return _myEvidence;
        }
        set => Set(ref _myEvidence, value);
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.MyEvidence = null;
    }
