    pairedValues.forech(x=> {
        x.GetListOfFiles()
         .Where(e => e.fileName == val.FileName)
         .ToList().foreach(y=> {
              //Create new record here (we don't know the property names)
              var newRecord = new MyTable();
              newRecord.FileName = y.Filename // or whater 
             //TODO Now add the new record to 
              _Entity.MyTable.Add(newRecord);
          });
    });
