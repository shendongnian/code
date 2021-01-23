    public class OccupationModel : INotifyPropertyChanged
    {
      private double salary;
      public double Salary
      {
        get
        {
          return this.salary;
        }
        set
        {
          if (this.salary != value)
          {
            this.salary = value;
            this.OnPropertyChanged("Salary");
          }
        }
      }
    }
