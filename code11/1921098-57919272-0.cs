     static void Main(string[] args)
            {
                var t = Task.Run(() => MyMethod());
            }
    
            static public async void MyMethod()
            {
                //some long running code
            }
