     public Window1()
            {
                InitializeComponent();
    
                this.DataContext = this;
    
                Doctors = new ObservableCollection();
                LoadDoctors();
            }
    
            private void LoadDoctors()
            {
                Doctors.Clear();
    
                foreach (var doctor in DB.GetDoctors())
                    Doctors.Add(doctor);
            }
