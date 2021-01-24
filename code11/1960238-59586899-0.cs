    class EntityBase
    {
        public string LogInfo()
        {
            return JsonConvert.Serialize(this);  //Just an example
        }
    }
