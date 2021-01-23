    public void Test(){
        object a = new object();
        Test(a);
        if(a==null)
            Debug.WriteLine("isNull");
        else
            Debug.WriteLine("isSet");
    }
    public void Test2(ref object obj){
        obj = null;
    }
