     public class Singleton
        {
            private static string _locker = new object();
            private static Singleton _instance = null;
            public string SerializedString="";
            
            ///Constructore is called just one time !
            public Singleton(arg1){
             DoSerialization(arg1);
             }
            public static Singleton Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_locker)
                        {
                            if (_instance == null)
                            {
                                _instance = new Singleton();
                            }
                        }
                    }
                    return _instance;
                }
            }
        private void DoSerialization(arg1){
          this.SerializedString=JsonConvert.SerializeObject(arg1)
         }
        }
