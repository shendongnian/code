    class EventClass
        {
            public void SomeMethod()
            {
                MyClass clss = new MyClass();    //note: MyClass implements INotifyPropertyChanged
                clss.DoSomething(new object());
                clss.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(MyEventHandler);
            }
    
            private static void MyEventHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                var customeEventArgs = (CustomEventArgs) e;
                Debug.WriteLine("some property on MyClass has changed! Extra Data : {0}", customeEventArgs.ExtraData);
            }
        }
