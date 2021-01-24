     public class ViewModel_Employee  : INotifyPropertyChanged
        {
           
            private ViewModel_Employee()
            {
    
            }
    
            private static ViewModel_Employee privateInstance = null;
            public static ViewModel_Employee Instance
            {
                get
                {
                    if (privateInstance == null)
                        privateInstance = new ViewModel_Employee();
    
                    return privateInstance;
                }
    
                // class is a singleton
    
            }
