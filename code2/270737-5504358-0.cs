    public void WriteMyFile(){
        try{
            using (FileStream fStream = File.Create(@"C:\test.txt")){
                string text = MyUtilities.GetFormattedText("hello world");
                MyUtilities.WriteTextToFile(text, fStream);
            }
        }
        catch(Exception e){
            //How do you test the code in here?
        }
    }
