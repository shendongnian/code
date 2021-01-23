    using System.Runtime.Serialization;
    . . .
    [DataContract]
    public class Settings {
        string Name;
        . . .
        [DataMember]
        public T Value {
        . . .
        }
