      public interface MyInterface
      {//methods common to all types
        void FirstMethod();
      }
      public interface MyInterface<T> : MyInterface
      {//methods specific to a type
        void FirstMethod(T parameter);
      }
      public class MyClassThatHandlesAllInterfaces
      {
        private List<MyInterface> _allInterfacesT; //first interface in the chain
        public void AddInterface<T>(MyInterface<T> ifToAdd)
        {
          _allInterfacesT.Add(ifToAdd); // <- this is what I'd like to do
        }
      }
