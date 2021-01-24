    class MyJsonObjectModel
    {
        public string otherProperty1 = "My string 1";
        public string otherProperty2 = "My string 2";
        public int otherProperty3 = "1";
        
        public empleado empleadoModel;
    }
    
    string jsonResult = JsonConvert.SerializeObject(MyJsonObjectModel);
