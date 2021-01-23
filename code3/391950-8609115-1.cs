    class TestSomeData
    {
        public TestSomeData(Label myControl) {
            this.MyControl = myControl;
        }
    
        private Label MyControl { get; set; }
    
        public void CheckSomeStuff()
        {
             if (this.MyControl == null) {
                 // throw ArgumentNullException or InvalidOperationException
             }
             foreach(string x in someList)
             {
                  this.MyControl.Content = x;
             }
         }
     }
