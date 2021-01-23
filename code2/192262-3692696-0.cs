    public class TestModel : INotifyPropertyChanged
    {
        int m_TestCounter;
        public int TestCounter {
			get {
				return m_TestCounter;
			}
			set {
				m_TestCounter = value;
				Changed("TestCounter");
			}
		}
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        void Changed(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
