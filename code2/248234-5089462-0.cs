    public class Address
    {
        private string _addressLine1;
        public string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }
        private string _addressLine2;
        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _state;
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _zip;
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
    }
    public class Employee
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private Address _employeeAddress;
        public Address EmployeeAddress
        {
            get { return _employeeAddress; }
            set { _employeeAddress = value; }
        }
    }
    class Program
    {
        #region Variabili Globali
        static private Contesto contesto;
        static private string file = ConfigurationManager.AppSettings["PathFileLog"];
        static EniLoggerManager log;
        static private ArrayList ListaMessaggi = null;
        #endregion
        public static object GetPropertyValueComplete(object obj, string pattern)
        {
            pattern = "x.Lista[#].Opzione.Codice";
            List<string> s = new List<string>(pattern.Split('.'));
            
            return GetPropertyValueComplete(obj, s);
            return "";
        }
        private static object GetPropertyValueComplete(object obj, List<string> s)
        {
            s.RemoveAt(0);
            if (s.Count == 1)
                return GetPropertyValue(obj, s[0]);
            foreach (string s1 in s)
            {
                if(s1.Contains("#"))
                {
                    object propertyValue = GetPropertyValue(obj, s1.Substring(0, s1.IndexOf('[')));
                    List<object> list = new List<object>();
                    for(int i = 0; i < 100; i++)
                    {
                        try
                        {
                            object value = GetPropertyValue(propertyValue, "Items", i);
                            if (value != null)
                                return GetPropertyValueComplete(value, (string) s);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
                else return GetPropertyValueComplete(obj, (string) s);
            }
        }
        public static object GetPropertyValue(object obj, string propertyName)
        {
            return GetPropertyValue(obj, propertyName, null);
        }
        public static object GetPropertyValue(object obj, string propertyName, int? index)
        {
            Type objType = obj.GetType();
            PropertyInfo prop = objType.GetProperty(propertyName);
            FieldInfo prop1 = objType.GetField(propertyName);
            if (prop == null && prop1 == null)
                throw new Exception(string.Format("Proprietà {0} non trovata nel tipo {1}", propertyName, objType));
            else if (prop != null)
            {
                object propertyValue;
                if (index == null)
                    propertyValue = prop.GetValue(obj, null);
                else
                    propertyValue = prop.GetValue(obj, new Object[] {index});
                return propertyValue;
            }
            else if(prop1 != null)
                return prop1.GetValue(obj);
            return null;
        }
