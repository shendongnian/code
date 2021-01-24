    public static ObjectId Parse(string s)
            {
                if (s == null)
                {
                    throw new ArgumentNullException("s");
                }
    
                ObjectId objectId;
                if (TryParse(s, out objectId))
                {
                    return objectId;
                }
                else
                {
                    var message = string.Format("'{0}' is not a valid 24 digit hex string.", s);
                    throw new FormatException(message);
                }
            }
    ....
    ....
    ....
    public static bool TryParse(string s, out ObjectId objectId)
        {
            // don't throw ArgumentNullException if s is null
            if (s != null && s.Length == 24)
            {
                byte[] bytes;
                if (BsonUtils.TryParseHexString(s, out bytes))
                {
                    objectId = new ObjectId(bytes);
                    return true;
                }
            }
            objectId = default(ObjectId);
            return false;
        }
