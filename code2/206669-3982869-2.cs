    public interface IValueWrapper {
        object Value { get; set; }
        bool HasValue { get; set; }
    }
    public class ValueWrapper<T> : IValueWrapper {
        public T Value { get; set; }
        object IValueWrapper.Value { 
            get { return Value; }
            set { this.Value = (T)value; }
        }
        public bool HasValue { get; set; }
        public ValueWrapper() {
            this.HasValue = false;
        }
        public ValueWrapper(T value) {
            this.Value = value;
            this.HasValue = value != null;
        }
    }
    public static class DictionaryExtensions {
        public static void Add<T>(
            this IDictionary<string, IValueWrapper> dictionary,
            string key,
            T value
        ) {
            ValueWrapper<T> valueWrapper = new ValueWrapper<T>(value);
            dictionary.Add(key, valueWrapper);
        }
        public static bool TryGetWrappedValue<T>(
            IDictionary<string, IValueWrapper> dictionary,
            string key,
            out ValueWrapper<T> value
        ) {
            IValueWrapper valueWrapper;
            if (dictionary.TryGetValue(key, out valueWrapper)) {
                value = (ValueWrapper<T>)valueWrapper;
                return true;
            }
            else {
                value = null;
                return false;
            }
        }
    }
