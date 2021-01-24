    string text = File.ReadAllText(file_path); 
    
    var currentList = JsonConvert.DeserializeObject<List<Datalogger>>(text)
    
    //Create new Datalogger
    
    Datalogger myself = new Datalogger
                    {
                        Record = 1,
                        IPaddress = textBox2.Text,
                        Machinename = textBox8.Text,
                        username = textBox4.Text,
                        password = textBox3.Text,
                        sourcefolder = textBox7.Text,
                        destfolder = textBox6.Text,
                        filextension = textBox5.Text,
    
                    };
    
    if(currentList != null && currentList.Any())
    {
    	var lastRecordNumner = currentList.OrderBy(q=>q.Record).Last().Record; 
    	myself.Record = lastRecordNumner + 1;	
    }
    else
    {
        currentList = new List<Datalogger>();
    }
    
    currentList.Add(myself);
    
    string output = Newtonsoft.Json.JsonConvert.SerializeObject(currentList, Newtonsoft.Json.Formatting.Indented);
    File.WriteAllText(filePath, output);
