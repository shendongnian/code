    namespace Security
    {
    /// <summary>
    /// Base class from which all Security Setting instances must inherit
    /// </summary>
    public abstract class SettingNameBase
    {
        /// <summary>
        /// Returns fully qualified type name of the instance of this class as a string
        /// </summary>
        public override string ToString()
        {
            return this.GetType().FullName;
        }
    }
    [DataContract]
    public class Settings
    {
        [DataMember]
        private Dictionary<String, Object> settings = new Dictionary<String, Object>();
        public void Add<T>(SettingNameBase name, T value)
        {
            if (!settings.ContainsKey(name.ToString()))
            {
                settings.Add(name.ToString(), value);
            }
            else
            {
                throw new ArgumentException(string.Format("A setting with the key '{0}' already exists.", name.ToString().Replace("+", ".")));
            }
        }
        public bool TryGetValue<T>(SettingNameBase name, out T value)
        {
            bool dictContainsKey = false;
            if (dictContainsKey = settings.ContainsKey(name.ToString()))
            {
                try
                {
                    value = (T)Convert.ChangeType(settings[name.ToString()], typeof(T));
                }
                catch (InvalidCastException ex)
                {
                    string errMsg = string.Format("Invalid cast of value '{0}' to type of {1} in Setting.Value<T>() method.",
                        settings[name.ToString()], typeof(T).FullName);
                    throw new InvalidCastException(errMsg, ex);
                }
            }
            else
            {
                value = default(T);
            }
            return dictContainsKey;
        }
    }
        public class SettingNames
        {
            /// <summary>
            /// Setting for a user
            /// </summary>
            public class User
            {
                public class Name : SettingNameBase { }
                public class ID : SettingNameBase { }
                public class Password : SettingNameBase { }
            }
    
            /// <summary>
            /// Setting for App1
            /// </summary>
            public class App1
            {
                public class Screen1
                {
                    public class CanEditField1 : SettingNameBase { }
                    public class MaxBillAmountToConsolidate : SettingNameBase { }
                }
                public class Screen2
                {
                    public class CanEditField2 : SettingNameBase { }
                    public class CanEditField3 : SettingNameBase { }
                }
            }
    
            /// <summary>
            /// Setting for App2
            /// </summary>
            public class App2
            {
                public class SingleSetting : SettingNameBase { }
            }
        }
    }
