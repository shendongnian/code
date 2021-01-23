    public Enum GetSensorTypeAtLocation(int x)
    {
       ...
       // Send serial command and receive response.
       string responseCommand = SendReceive(String.Format("SR,ML,{0},\r", x));
    
       //Try to parse the response into a value from one of the enums;
       //the first one that succeeds is our sensor type.
       SensorTypeA typeAresult;
       if(Enum.TryParse(responseCommand, typeAResult)) return typeAresult;
       SensorTypeB typeBresult;
       if(Enum.TryParse(responseCommand, typeBResult)) return typeBresult;
       SensorTypeC typeCresult;
       if(Enum.TryParse(responseCommand, typeCResult)) return typeCresult;
    }
