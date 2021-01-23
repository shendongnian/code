    public interface IId { }
    public struct Id<T>: IId {
        private readonly int _value;
        public Id(int value) {
            this._value = value;
        }
        public static implicit operator int(Id<T> id) {
            return id._value;
        }
        public static explicit operator Id<T>(int value) {
            return new Id<T>(value);
        }
    }
    public struct Person { }  // Dummy type for person identifiers: Id<Person>
    public struct Product { } // Dummy type for product identifiers: Id<Product>
