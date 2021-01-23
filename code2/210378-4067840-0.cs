    public class A
      {
        private static int _num = 1;
        public  virtual int Num { get { return _num; } set { _num = value; } }
        public int GetClassNum<T>(T input) where T : A
        {
          return input.Num;
        }
      }
