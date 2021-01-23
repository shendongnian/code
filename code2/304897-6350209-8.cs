    public class BaseEntity
    {
       void Restore(Stream stream)
       {
          object deserialized = EntityBackupServices.RestoreDeserialize(stream);//As listed above
          if (deserialized.GetType () != this.GetType ())
             throw new Exception();
          foreach (FieldInfo fi in GetType().GetFields())
          {
             fi.SetValue(this, fi.GetValue (deserialized));
          }
       }
    }
