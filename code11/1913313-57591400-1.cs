    public bool SendUsersBirthdayEmailsAsync(){
        try{
            SendMail();
        }
        catch(Exception e){
            LogException(e);
        }
        //optional
        finally{
            OptionalWork();
        }       
    }
