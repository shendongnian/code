    public class DataContractNameResolver
    {
        private Type TypeOfDataContract = null;
        private Dictionary<System.Xml.XmlQualifiedName, Type> xmlNames = new Dictionary<System.Xml.XmlQualifiedName, Type>();
        internal void PrecacheBaseTypes(IEnumberable<Type> types)
        {
            if (TypeOfDataContract == null)
            {
                TypeOfDataContract = Type.GetType("System.Runtime.Serialization.DataContract, System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            }
            lock (xmlNames)
            {
                var remaining = new Queue<Type>(types.Except(xmlNames.Values));
                while (remaining.Count > 0)
                {
                    Type next = remaining.Dequeue();
                    var dc = Impromptu.InvokeMember(TypeOfDataContract.WithStaticContext(), "GetDataContract", next);
                    IDataContract result = Impromptu.ActLike<IDataContract>(dc);
                    xmlNames.Add(new System.Xml.XmlQualifiedName(result.Name.Value, result.Namespace.Value), next);
                }
            }
        }
        public Type ResolveName(System.Xml.XmlQualifiedName typeName)
        {
            if (xmlNames.ContainsKey(typeName))
            {
                return xmlNames[typeName];
            }
            return null;
        }
    }
