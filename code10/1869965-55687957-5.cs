    //member variable for select grade
    private int _selectedGrade = 0;
    //List of Coefficients (renamed from SelectedGrade)
    public ObservableCollection<double> Coefficients { get; set; } = new ObservableCollection<double>() { 0 };
    //Available (valid) Grades to select from in the ComboBox
    public List<int> AvailableGrades { get; private set; } = Enumerable.Range(0, 11).ToList();
    //Currently selected grad with logic to adjust the coefficient amount
    public int SelectedGrade
    {
        get { return _selectedGrade; }
        set
        {
            _selectedGrade = value;
            //Clear Coefficients and add the necessary amount
            Coefficients.Clear();
            for (int i = 0; i <= _selectedGrade; i++) { Coefficients.Add(0); }
        }
    }
