    [Test]
    public void Test1()
    {
        .....
        try{
           WfcServiceCall(...);
           Assert.Fail("a FaultException<PermissionDenied_Error> was expected!");
        }catch(FaultException<PermissionDenied_Error>){
           Assert.Sucess();
        }catch(Exception e){
           Assert.Fail("Unexpected exception!")
        }
    }
