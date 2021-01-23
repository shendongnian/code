    class TestSomeData
    {
        public TestSomeData(Label myControl) {
            this.MyControl = myControl;
        }
    
        private Label MyControl { get; set; }
    
        public void CheckSomeStuff()
        {
             foreach(string x in someList)
             {
                  this.MyControl.Content = x;
             }
         }
     }
