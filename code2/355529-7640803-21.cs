    public interface IDataValueReader
    {
        // Signature is one that might be able to support ini files:
        // string -> string; then cast
        //
        // As well as a DB reader:
        // string -> strongly typed object
        T ReadValue<T>(string valueName);
    }
    public class DbDataReader : IDataValueReader
    {
        private readonly SqlDataReader reader;
        public DbDataReader(SqlDataReader reader)
        {
            this.reader = reader;
        }
        object ReadValue<T>(string fieldId)
        {
            return (T)reader.GetObject(reader.GetOrdinal(fieldId));
        }
    }
    public class IniDataSectionReader : IDataValueReader
    {
        private readonly IniFileSection fileSection;
        public IniDataSectionReader(IniFileSection fileSection)
        {
            this.fileSection = fileSection;
        }
        object ReadValue<T>(string valueName)
        {
            return (T)Convert.ChangeType(fileSection.GetValue(fieldId), typeof(T));
        }
    }
