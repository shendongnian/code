    public class MyCustomeEx : Exception
    {
        int CustID { get; set; }
    }
    public void Fail()
    { 
        //Awww Customer error
        throw new MyCustomeEx () {CustID = 123}
    }
    
