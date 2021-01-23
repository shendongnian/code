    public class PersonModel : INotifyPropertyChanged
    {
      private string occupation;
      public string Occupation
      {
        get
        {
          return this.occupation;
        }
        set
        {
          if (this.occupation != value)
          {
            this.occupation = value;
            this.OnPropertyChanged("Occupation");
          }
        }
      }
    }
    public class PersonViewModel: INotifyPropertyChanged
    {
      private PersonModel model;
      public string Occupation
      {
        get
        {
          return this.model.Occupation;
        }
        set
        {
          this.model.Occupation = value;
        }
      }
      public PersonViewModel(PersonModel model)
      {
        this.model = model;
        this.model.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);
      }
      private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
        this.OnPropertyChanged(e.PropertyName);
      }
    }
