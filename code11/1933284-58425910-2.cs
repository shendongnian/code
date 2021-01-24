    public void Save()
    {
    
    
        //--Get Text typed in the input box
        savedName = saveName.text;
    
        //--Combing list of string into a single string
        string jsons = "[" + string.Join(",", jsonstring) + "]";
    
        //Writing into a JSON file in the persistent path
        using (FileStream fs = new FileStream(
                Path.Combine(Application.persistentDataPath, savedName+".json"), 
                FileMode.Create))
        {
            BinaryWriter filewriter = new BinaryWriter(fs);
    
            filewriter.Write(jsons);
            fs.Close();
    
        }
    
        saveButtonShow.SetActive(false);
    
    }
