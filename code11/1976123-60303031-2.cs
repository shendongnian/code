    public class MyData
    {
        //map the raw input to this field as a string
        public string MappedIntField {get;set;}=null;
        
        // use an integer property not mapped to any column to shadow the string, and lazy-convert to an integer the first time you read it.
        public int ActualIntField 
        {
            get {
                if (MappingReady || string.IsNullOrEmpty(MappedIntField)) return _ActualIntField;
                //clean up the extra = character.
                if (MappedIntField[0] == '=') MappedIntField = MappedIntField.Substring(1);
     
                int result; 
                if (int.TryParse(MappedIntField, out result))
                {
                     _ActualIntField = result;
                     MappingReady = true;
                     return result;
                }
                return _ActualIntField;             
            }
            set {
                _ActualIntField = value;
                MappingReady = true;
            }
        }
        private int _AcutalIntField;
        // We don't want to re-parse the string on every read, so also flag when this work is done. You could also use a nullable int? to do this.
        private bool MappingReady = false;
    }
