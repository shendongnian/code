    public class JFile
    {
        ...
        protected Dictionary Metadata() { ... }
        ...
       
        // --> all this use "Dictionary" internally
        // --> but, do somthing to other "IFile" fields
        public String GetValue(String key) { ... }
        public void SetValue(String key, String value)  { ... }
        public Boolean Contains(String key)  { ... }
        public void Delete(String key)  { ... }
    }
