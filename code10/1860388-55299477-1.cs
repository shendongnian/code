    public class Request 
    {
        private static int _index = 1;
        public Request (){
          Index =  _index  ++;
        }
        public int Index {get;set;}
        public string DocType {get;set;}
        public string DocId {get;set;}
    }
