    // class for position values
    public class PositionData
    {
        public int X;
        public int Y;
        public int Z;
    }
    
    // poll position from Android (usbController is initialised somewhere else)
    public PositionData ReadPositionData()
    {
        var data = usbController.Call<AndroidJavaObject>("getCurrentPosition");
    
        if (data == null)
        {
            Debug.LogError("Could not retrieve data from Android.");
            return null;
        }
        
        var positionData = new PositionData
        {
            X = data.Get<int>("x"),
            Y = data.Get<int>("y"),
            Z = data.Get<int>("z")
        };
    
        return positionData;
    }
