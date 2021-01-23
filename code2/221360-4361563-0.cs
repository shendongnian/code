    [DataContract]
    public class Author
    {
        [DataMember]
        private string FN, N, P;
        public string FamilyName
        {
            get { return FN; }
        }
        public string Name
        {
            get { return N; }
        }
        public string Patronymic
        {
            get { return P; }
        }
        public Author(string familyName, string name, string patronymic)
        {
            FN = familyName;
            N = name;
            P = patronymic;
        }
    }
