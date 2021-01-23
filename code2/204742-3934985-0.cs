    public class CustomData
    {
        public string name;
        public int id;
    }
    [WebMethod()]
    public static CustomData ReturnCustomData(string MyName, int MyID)
    {
        CustomData MyData = new CustomData();
        MyData.name = MyName;
        MyData.id = MyID;
        return MyData;
    }
