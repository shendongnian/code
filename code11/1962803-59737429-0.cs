    public MainWindow()
    {
        InitializeComponent();
        List<Candidate> tmp = new List<Candidate>();
        tmp.Add(new Candidate()
        {
            CandidateID = 1,
            CandidateName = "One",
            RegisterNo = 1
        });
        tmp.Add(new Candidate()
        {
            CandidateID = 2,
            CandidateName = "Two",
            RegisterNo = 2
        });
        tmp.Add(new Candidate()
        {
            CandidateID = 3,
            CandidateName = "Three",
            RegisterNo = 3
        });
        dgCandidate.ItemsSource = tmp;
        foreach (Candidate candidate in tmp)
        {
            candidate.PropertyChanged += Candidate_PropertyChanged;
        }
    }
    private void Candidate_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        _handle = false;
        chkSelectAll.IsChecked = (dgCandidate.ItemsSource as IEnumerable<Candidate>)?
            .All(x => x.IsSelected) == true;
        _handle = true;
    }
    private bool _handle;
    private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
    {
        if (_handle && dgCandidate.IsLoaded)
        {
            foreach (Candidate c in dgCandidate.ItemsSource)
            {
                c.IsSelected = true;
            }
        }
    }
    private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
    {
        if (_handle)
        {
            foreach (Candidate c in dgCandidate.ItemsSource)
            {
                c.IsSelected = false;
            }
        }
    }
