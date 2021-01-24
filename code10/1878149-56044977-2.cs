    //you need an ObservableCollection for each list
    public ObservableCollection<sensorType> SensorData1 {get;set;}
    //then create the command or method to add the data to their respective Collection
    public void SetNewSensorData(sensorType sData1, sensorType sData2, sensorType sData3){
       
      //...then add the new data (with extra logic as needed)
      SensorData1.add(sData1);
      SensorData2.add(sData2);
      SensorData3.add(sData3);
    }
