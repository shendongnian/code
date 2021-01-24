       public ObservableCollection<DrugInventoryItem> PlayerDrugs
        {
            get { return Player1Drugs; }
            set { Player1Drugs = value; OnPropertyChanged(); }
        }
