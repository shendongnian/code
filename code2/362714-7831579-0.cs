     private ListCollectionView EmpCollectionView
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(ListOfEmp);
            }
        }
        private ObservableCollection<Employee> listOfEmp = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> ListOfEmp
        {
            get { return listOfEmp; }
            set { listOfEmp = value; }
        }
