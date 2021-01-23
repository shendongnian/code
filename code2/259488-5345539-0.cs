    public abstract class BaseClass
    {
        private Type _classType;
        public Type ClassType
        {
            get
            {
                return _classType;
            }
            set
            {
                _classType= value;
            }
        }
        public abstract Type GetType();
    }   
    public class InheritedClass: BaseClass
    {
        public override Type GetType()
        {
            if (ClassType == null)
            {
                ClassType = typeof(InheritedClass);//ie SingleInfringement or DblInfringment
            }
            return ClassType;
        }
    }
