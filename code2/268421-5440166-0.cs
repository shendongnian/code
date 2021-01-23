	public partial class Student
	{
		public Decimal TotalCosts
		{
			get { return (LodgingCosts + RegistrationCosts + TravelCosts + DiningCosts); }
		}
		public Student()
		{
			this.PropertyChanged += new PropertyChangedEventHandler(Student_PropertyChanged);
		}
		void Student_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "LodgingCosts" ||
				e.PropertyName == "RegistrationCosts" ||
				e.PropertyName == "TravelCosts" ||
				e.PropertyName == "DiningCosts")
			{
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("TotalCosts"));
			}
		}
	}
