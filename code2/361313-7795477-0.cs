    if(textToTest.Contains("@")){
        try{
             mail = new MailAdress(textToTest);
        }catch(Exception e){
        }
    }else{
        plainText = textToTest
    }
