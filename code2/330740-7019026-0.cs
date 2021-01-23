        public class GenericObjs
        {
            private List<object> objs = new List<object>();
            public List<object> Objs { get { return objs; } set { objs = value; } }
            public GenericObjs(List<object> Objs) { objs = Objs; }
        }
