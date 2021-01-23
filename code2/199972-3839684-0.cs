    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {
        public override string ToString()
        {
            return lname.ToString() + ", " + fname.ToString();
        }
    }
