    public class SomeClass {
        Base<T> GetItem<T> where T : Base<T> {
            get { throw new NotImplementedException(); }
        }
    }
