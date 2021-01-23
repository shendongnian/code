        public class FileParameters   {    }
    
        public class SpecialFileParameters : FileParameters{}
    
        public abstract class File<T>
            where T : FileParameters
        {
            private T _params;
    
            public T Params   { get { return _params;}        }
        }
    
        public class SpecialFileParams : FileParameters<SpecialFileParameters> { }
