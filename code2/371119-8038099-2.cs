        try
        {
          SomeClass.IsSerializing = true;
          deserializedClass = (SomeClass)serializer.Deserialize(reader);
        }
        finaly
        {
          SomeClass.IsSerializing = false;  //make absolutely sure you set it back to false
        }
