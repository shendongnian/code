    public class DocumentLoaderTest
    {
        public void Test()
        {
            DocumentLoader loader = new DocumentLoader(File.Open("D:\\sampleSource.xml", FileMode.Open));
            //now names contains the value of the name element 
            List<KeyValuePair<string,string>>names=loader.GetNames();
        }
    }
