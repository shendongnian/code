    public void Dispose(){
        if(Marshal.GetExceptionCode()==0){
            // disposing normally
            Commit();
        }else{
            // disposing because of exception.
            Rollback();
        }
    }
