    class myClass  
    {      
        public string foo { get; set; }
        public string bar { get; set; }        
        public myClass()      
        {          
            //does some stuff here     
        }
        public static myClass FromReader(Reader reader)
        {
            return (myClass)deserializer.Deserialize(reader); 
        }
    }
