    public interface IEncryptedStringSerializer : IBsonSerializer<EncryptedString> {} 
   
    public class EncryptedStringSerializer : SerializerBase<EncryptedString>, IEncryptedStringSerializer
    {
        private readonly IDeterministicEncrypter _encrypter;
        private readonly string _encryptionKey;
        public EncryptedStringSerializer(IConfiguration configuration, IDeterministicEncrypter encrypter)
        {
            _encrypter = encrypter;
            _encryptionKey = configuration.GetSection("MongoDb")["EncryptionKey"];
        }
        public override EncryptedString Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var encryptedString = context.Reader.ReadString();
            return _encrypter.DecryptStringWithPassword(encryptedString, _encryptionKey);
        }
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, EncryptedString value)
        {
            var encryptedString = _encrypter.EncryptStringWithPassword(value, _encryptionKey);
            context.Writer.WriteString(encryptedString);
        }
    }
