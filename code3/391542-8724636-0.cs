    Sequential file access File using serialization
    Add
    Using system.Io
    Using system.Runtime.Serialzation.Formatters.Binary
    Using System.Runtime.Serialization
    Using Macro Events
    name space created fileform  : macroform
    //Object For serializing RecordSerializables in binary format
    Private Binary formatter = new binaryFormatter();
    Private file stream output; //stream for writing to a file
