    public static void Test()
    {
        string xmlData = "<root><Name1 Type=\"System.String\">Value1</Name1><Name2 Type=\"System.Int32\">324</Name2></root>";
        List<DataField> dataFieldList = DataField.ConvertXML(xmlData);
        Debug.Assert(dataFieldList.Count == 2);
        Debug.Assert(dataFieldList[0].GetType() == typeof(DataField<string>));
        Debug.Assert(dataFieldList[1].GetType() == typeof(DataField<int>));
    }
    public abstract class DataField
    {
        public string Name { get; set; }
        /// <summary>
        /// Instanciate a generic DataField<T> given an XElement
        /// </summary>
        public static DataField CreateDataField(XElement element)
        {
            //Determine the type of element we deal with
            string elementTypeName = element.Attribute("Type").Value;
            Type elementType = Type.GetType(elementTypeName);
            //Instanciate a new Generic element of type: DataField<T>
            DataField dataField = (DataField)Activator.CreateInstance(typeof(DataField<>).MakeGenericType(elementType));
            dataField.Name = element.Name.ToString();
            //Convert the inner value to the target element type
            object value = Convert.ChangeType(element.Value, elementType);
            //Set the value into DataField
            PropertyInfo valueProperty = dataField.GetType().GetProperty("Value");
            valueProperty.SetValue(dataField, value, null);
            return dataField;
        }
        /// <summary>
        /// Take all the descendant of the root node and creates a DataField for each
        /// </summary>
        public static List<DataField> ConvertXML(string xmlData)
        {
            var result = (from d in XDocument.Parse(xmlData).Root.DescendantNodes().OfType<XElement>()
                          select CreateDataField(d)).ToList();
            return result;
        }
    }
