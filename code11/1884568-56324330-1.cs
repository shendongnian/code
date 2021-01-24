       using Prism.Mvvm;
    namespace WpfApp2
    {
        public class MyType : BindableBase
        {
            private int _myVar;
    
            public int MyVar
            {
                get { return _myVar; }
                set
                {
                    if (Equals(_myVar, value)) return;
                    SetProperty(ref _myVar, value);
                    if (MyPair!=null)
                    {
                        MyPair.MyVar = value;
                    }
                }
            }
    
            public MyType()
            {
                MyVar = 0;
            }
    
            MyType MyPair { get; set; }
    
            public void SetPair(ref MyType pair)
            {
                MyPair = pair;
            }
    
            public MyType GetPair()
            {
                return MyPair;
            }
        }
    }    
