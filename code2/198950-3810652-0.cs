    public static Exception Invoke(string soapMessage) {
        //...            
        string _message = doc.DocumentElement.InnerText;
        Type_type = Type.GetType(doc.DocumentElement.Attributes["Type"].Value);
        ConstructorInfo constructor = _type.GetConstructor(new[] {typeof (string), _type.GetType()});
        try {
            Exception ctor = (Exception)constructor.Invoke(new object[] { _message, _type });
        } catch (Exception ex) {
            return ex;
        }
        return null;
    }
