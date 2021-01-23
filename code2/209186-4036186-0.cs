    public struct MyButtonData {
        public int myInt;
        public string myString;
    }
    ...
    
    bn.Tag = new MyButtonData() {myInt = 3, myString = "Hello World"};
    ...
    var data = (MyButtonData)bn.Tag;
