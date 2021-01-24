    //Unfortunately it is not possible to use a Value Type and bind to it due it has no Getter/Setter therefore we need a little wrapper
    public class ValueTypeAsClass<T>
    {
        public T Value { get; set; }
        public static implicit operator ValueTypeAsClass<T>(T v)
        {
            return new ValueTypeAsClass<T> { Value = v };
        }
        public static implicit operator T(ValueTypeAsClass<T> v)
        {
            return v.Value;
        }
    }
    //member variable for select grade
    private int _selectedGrade = 0;
    //List of Coefficients (renamed from SelectedGrade)
    public ObservableCollection<ValueTypeAsClass<double>> Coefficients { get; set; } = new ObservableCollection<ValueTypeAsClass<double>>() { 0d };
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
