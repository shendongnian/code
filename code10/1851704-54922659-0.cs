    public class CustomData
    {
        public string Input;
        public string Output;
    }
...
    CustomData data = new CustomData();
    data.Input = "Something";
    gameInstance.SendMessage("MyObjectName", "MyFunctionName", data);
    //use data.Input inside MyFunctionName like a parameter
    //change data.Output inside MyFunctionName
    //use data.Output
    Debug.Log(data.Output);
