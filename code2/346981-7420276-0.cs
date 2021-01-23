    public Meal()
    		{
    			RemoveMealCommand = new RelayCommand(() => RemoveMealCommandExecute());
    		}
    
    		public RelayCommand RemoveMealCommand
    		{
    			get;
    			set;
    		}
    
    		public delegate void RemoveMealEventHandler(object sender, EventArgs e);
    		public event RemoveMealEventHandler RemoveMealEvent;
    
    		private void RemoveMealCommandExecute()
    		{
    			RemoveMealEvent(this, null);
    		}
