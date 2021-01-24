namespace MVVM_Basics.Commands
{
    //the following class is used to retrieve data that is in an XML document. The document is name Customer.xml and is located in the data folder.
    //We are using the Deserialize feature to grab info needed from the XML doc and then data bind it to parts of a View through that View's ViewModel
    public class Serializer
    {
        /// <summary>
        /// populate a class with xml data 
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="input">xml data</param>
        /// <returns>Object Type</returns>
        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
        /// <summary>
        /// convert object to xml string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ObjectToSerialize"></param>
        /// <returns></returns>
        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
then in my ViewModel I created a customer variable and variable that contain the path to my XML. I then applied the deserialized data to the Customer creating my Customer object. 
//setting up some variable that will be use through this class
        // the private read only is setting up a Customer data type that will have a customer object attached to it
        private readonly Customer customer;
        string path = Directory.GetCurrentDirectory() + @"\Customer.xml"; 
        string xmlInputData = string.Empty;
        public CustomerViewModel()
        {
            //we are defining that we are using the CustomerUpdateCommand with this ViewModel on construction of 'this' ViewModel
            UpdateCommand = new CustomerUpdateCommand(this);
            
            //the 'path' variable is the path to the XML file containing all Customer data, we first just check the file does exist, we then create 
            //an instance of the Serializer class and use that class on the XML file using the Deserialize method from the class. Then attached the data to an
            //instance of a Customer object that we created a 'private readonly' variable for. 
            if (File.Exists(path))
            {
                xmlInputData = File.ReadAllText(path);
            }
            Serializer ser = new Serializer();
            customer = ser.Deserialize<Customer>(xmlInputData);
            
        }
