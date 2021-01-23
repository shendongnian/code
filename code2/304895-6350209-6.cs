    public static class EntityBackupServices
    {
       public static MemoryStream Backup (BaseEntity entity)
       {
          var ms = new MemoryStream();
          Serialize (ms, entity);
          ms.Position = 0;
          return ms;
       }
       public static void Serialize (Stream stream, BaseEntity entity)
       {
          var binaryFormatter = new BinaryFormatter();
          binaryFormatter.Serialize (stream, entity);
       }
       public static BaseEntity Restore (Stream stream)
       {
          var binaryFormatter = new BinaryFormatter();
          var entity = (BaseEntity) binaryFormatter.Deserialize (stream);
          return entity;
       }
    }
