    public void WriteMyFile(IFileRepository aRepository){
        try{
            using (FileStream fStream = aRepository.Create(@"C:\test.txt")){
                string text = MyUtilities.GetFormattedText("hello world");
                aRepository.WriteTextToFile(text, fStream);
            }
        }
        catch(Exception e){
            //You can now mock Create or WriteTextToFile and have it throw an exception to test this code.
        }
    }
