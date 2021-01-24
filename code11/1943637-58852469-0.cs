     /// <summary>
        ///     Converts an object to xml string
        /// </summary>
        /// <typeparam name="T">the type of the object</typeparam>
        /// <param name="typeOfObjectToConvert">the object that needs to be serialized</param>
        /// <returns>xml string</returns>
        public static string ConvertObjectToPlainXmlString<T>(
            T typeOfObjectToConvert)
        {
          
               var serializer =  new XmlSerializer(typeof(T));
                var sw = new Utf8StringWriter();
                serializer.Serialize(sw, typeOfObjectToConvert);
                return sw.ToString();
               
        }
