        public void Serialize(Employees emps, String filename)
        {
            //Create the stream to add object into it.
            MemoryStream ms = new MemoryStream();
            //Format the object as Binary
            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object
            formatter.Serialize(ms, emps);
            // Your employees object serialised and converted to a string.
            string encodedObject = Convert.ToBase64String(ms.ToArray());
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }
This creates the string 'encodedObject'. To retrieve the byte array and your serialised object back from the string you will use the below code.
            BinaryFormatter bf = new BinaryFormatter();
            // Decode the string back to a byte array
            byte[] decodedObject = Convert.FromBase64String(encodedObject);
            // Create a memory stream and pass in the decoded byte array as the parameter
            MemoryStream memoryStream = new MemoryStream(decodedObject);
            // Deserialise byte array back to employees object.
            Employees employees = bf.Deserialize(memoryStream);
