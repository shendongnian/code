    private delegate void YourDelegate(obj param1,obj param2);
    
    private void YourFunction(obj param1,obj param2)
    {
     //Write Code Here
    }
    
    //Call this from your Thread
     this.Invoke(new YourDelegate(YourFunction), new object[] { param1,param2});
