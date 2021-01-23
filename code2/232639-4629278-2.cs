    public class PersonViewModel: INotifyPropertyChanged
    {
      private PersonModel model;
      public double OccupationSalary
      {
        get
        {
          return this.model.Occupation.Salary;
        }
        set
        {
          this.model.Occupation.Salary = value;
        }
      }
      public PersonViewModel(PersonModel model)
      {
        this.model = model;
        this.model.Occupation.PropertyChanged += new PropertyChangedEventHandler(occupation_PropertyChanged);
      }
      private void occupation_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
        this.OnPropertyChanged("Occupation" + e.PropertyName);
      }
    }
