    public class Car : ICar
    {
        public bool EngineLight { get; set; }
    
        public void GetOilChange()
        {
        }
    
        public bool CheckEngineLight()
        {
            if (EngineLight)
            {
                GetOilChange();
                return true;
            }
    
            return false;
        } 
    }
