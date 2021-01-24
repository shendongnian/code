    public class OrderSerializer : SerializerBase<Order>
    {
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Order value)
    {
      context.Writer.WriteStartDocument();
      if (value.Currency != Order.DefaultCurrency)
      {
        context.Writer.WriteName(nameof(Order.Currency));
        context.Writer.WriteString(value.Currency);
      }
      context.Writer.WriteName(nameof(Order.Value));
      context.Writer.WriteDecimal128(value.Value);
      context.Writer.WriteEndDocument();
    }
    public override Order Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
      context.Reader.ReadStartDocument();
      var currency = Order.DefaultCurrency;
      var value = default(decimal);
      while (context.Reader.ReadBsonType() != BsonType.EndOfDocument)
      {
        var name = context.Reader.ReadName();
        switch (name)
        {
          case nameof(Order.Value):
            value = (decimal)context.Reader.ReadDecimal128();
            break;
          case nameof(Order.Currency):
            currency = context.Reader.ReadString();
            break;
          default:
            throw new FormatException();
        }
      }
      context.Reader.ReadEndDocument();
      return new Order(value, currency);
    }
    }
