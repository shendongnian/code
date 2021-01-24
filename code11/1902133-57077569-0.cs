        public ObservableCollection<string> All
        {
            get { return GetAllErrors(); }
        }
        public ObservableCollection<string> GetAllErrors()
        {
            ObservableCollection<string> allErrors = new ObservableCollection<string>();
            foreach(string i in FirstName)
            {
                allErrors.Add(i);
            }
            foreach (string i in LastName)
            {
                allErrors.Add(i);
            }
            return allErrors;
        }
