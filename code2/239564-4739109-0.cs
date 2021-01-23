        public interface IRepository : IRead
        {
            void Write(object o);
        }
        public interface IRead
        {
            object Read();
        }
