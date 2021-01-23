    string str = ...;
    ...
    var t = str.GetType(); // This is really useless. If str is null
                           // an exception is thrown. Otherwise the
                           // t will ALWAYS be typeof(string) because
                           // the class System.String is a sealed class.
