    public class MyObject
    {
        public LevelEnum MyValue {get;set,};
    }
    
    
    var obj = new MyObject();
    obj.GetType().GetProperty("MyValue").SetValue(LevelEnum.CDD, null);
