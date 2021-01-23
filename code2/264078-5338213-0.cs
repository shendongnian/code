    [EseTable, DataContract]
    public class User
    {
        /// <summary>Nickname.</summary>
        [EseText(bUnicode=true, maxChars=71), DataMember]
        public string displayName;
    }
