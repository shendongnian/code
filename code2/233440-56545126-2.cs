    static void SerializeRecord<T>(T record) where T: PaymentSummary
    {
      var serializer = new XmlSerializer(record.GetType());
      serializer.Serialize(Console.Out, record);
      Console.WriteLine(" ");
      Console.WriteLine(" ");
    }
