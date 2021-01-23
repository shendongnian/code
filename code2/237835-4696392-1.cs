       public class XmlDataManager 
    {
        const String XML_FILE_WRITE_FAIL = "Could not write to xml file";
        const String XML_FILE_READ_FAIL = "Could not read from xml file";
        const String XML_FILE_WRITE_BUILDER_FAIL = "Could not write values to string";  
       /// <summary>
        /// 
        /// </summary>
        public struct Delimeter
        {
            internal String StartDelimeter { get { return _startDelimeter; } }
            internal String EndDelimeter { get { return _endDelimeter; } }
            private readonly String _startDelimeter;
            private readonly String _endDelimeter;
            public Delimeter(String startDelimeter, String endDelimeter)
            {
                _startDelimeter = startDelimeter;
                _endDelimeter = endDelimeter;
            }
            public Delimeter(String startDelimeter)
            {
                _startDelimeter = startDelimeter;
                _endDelimeter = String.Empty;
            }
        }
        public static void ReadValuesLineByLine(    List<Delimeter> elementDelimeters, 
                                                    List<String> values, 
                                                    String fileName, 
                                                    int[] splitIndexes)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    String line = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        for (int i = 0; i <= values.Count-1; i++)
                        {
                            if (line.Contains(elementDelimeters[i].StartDelimeter))
                            {
                                String[] delimeters = { elementDelimeters[i].StartDelimeter, elementDelimeters[i].EndDelimeter };
                                String[] elements = line.Split(delimeters, StringSplitOptions.None);
                                values[i] = elements[splitIndexes[i]];
                            }
                        }
                         line = sr.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(XML_FILE_READ_FAIL, ex);
            }
        }
    }
