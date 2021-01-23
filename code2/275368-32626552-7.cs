    public class employee //: EntityObject
    {
				
        #region Primitive Properties
    
        public global::System.DateTime hire_date
        {
            get
            {
                return _hire_date;
            }
            set
            {
                //Onhire_dateChanging(_hire_date);
                _hire_date=value;
                Onhire_dateChanged();
            }
        }
		private DateTime _hire_date;
		void Onhire_dateChanged()
		{
                var handler = this.PropertyChanged; // copy before access (to aviod race cond.)
				if (handler != null)
				{					
					var args=new PropertyChangedEventArgs() { PropertyName="hire_date" };
					handler(this, (System.EventArgs)args);
				}
		}
			
		public event EventHandler PropertyChanged;
        #endregion
    }
	public class PropertyChangedEventArgs: System.EventArgs
	{
		public string PropertyName  { get; set; }
	}
	
