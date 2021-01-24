        const string myDataFilename= "myData.json";
        const string backupFolderPath = "ms-appx:///DataModel/";
        async Task LoadData()
        {
            string json = await StorageApi.ReadFromFile(myDataFilename, backupFolderPath + myClassFilename);
            try
            {
                myList = JsonConvert.DeserializeObject<List<myClass>>(json);
            }
            catch
            {
                // maybe do some reset logic here
                await StorageApi.CopyFile(backupFolderPath + myDataFilename, myDataFilename);
                await LoadData();
            }
        }
        
        async public void saveData()
        {
            string json = JsonConvert.SerializeObject(myList);
            await StorageApi.WriteToFile(myDataFilename, json);
        }
