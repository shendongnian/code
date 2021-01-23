    public class InformationHiding
    {
        private string _name;
        public string Name
        {
           get { return _name; }
           set { _name = value; }
        }
        /// This example ensures you can't have a negative age
        /// as this would probably mess up logic somewhere in
        /// this class.
        private int _age;
        public int Age
        {
           get { return _age; }
           set { if (value < 0) { _age = 0; } else { _age = value; } }
        }
    }
