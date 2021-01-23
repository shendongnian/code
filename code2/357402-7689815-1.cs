    public SensorType GetSensorTypeAtLocation(int x)
    {
       ...
       // Send serial command and receive response.
       string responseCommand = SendReceive(String.Format("SR,ML,{0},\r", x));
    
       // Process response command string and return result.
       SensorTypeA typeAresult;
       if(Enum.TryParse(responseCommand, typeAResult)) return SensorType.A;
       SensorTypeB typeBresult;
       if(Enum.TryParse(responseCommand, typeBResult)) return SensorType.B;
       SensorTypeC typeCresult;
       if(Enum.TryParse(responseCommand, typeCResult)) return SensorType.C;
    }
