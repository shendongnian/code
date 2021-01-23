    public class ClientConfiguration
    {
        private readonly IXmlSerializer serializer;
        public ClientConfiguration(IXmlSerializer serializer)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            this.serializer = serializer;
        }
        public virtual bool Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                this.serializer.Serialize(writer, this);
            }
            return true;
        }
    }
