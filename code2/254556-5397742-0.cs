    public class ToStringConverter {
        internal string Convert(object objectToConvert) {
            return objectToConvert.ToString();
        }
    }
    public class ThrowingConverter {
        internal string Convert(object objectToConvert) {
            if (objectToConvert is string) {
                return (string)objectToConvert;
            }
            throw new InvalidOperationException();
        }
    }
