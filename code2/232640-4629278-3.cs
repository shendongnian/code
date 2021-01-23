    public class OccupationViewModel : INotifyPropertyChanged
    {
      private OccupationModel model;
      public double Salary
      {
        get
        {
          return this.model.Salary;
        }
        set
        {
          this.model.Salary = value;
        }
      }
      public OccupationViewModel(OccupationModel model)
      {
        this.model = model;
        this.model.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);
      }
      private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
        this.OnPropertyChanged(e.PropertyName);
      }
    }
