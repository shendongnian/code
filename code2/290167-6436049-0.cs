    private <YourObject> datagridselectedItem;
    public <YourObject> DatagridselectedItem
        {
            get { return datagridselectedItem; }
            set
            {
                datagridselectedItem = value;
                this.RaisePropertyChanged("DatagridselectedItem");
            }
        }
