    public class AAccessor : A
    {
        // use this instead of Identificator
        public string IdentificatorAccessor 
        {
            get { return this.Identificator; }
            set { this.Identificator = value; }
        }
        // test this method in your unit test
        public void DoSomethingAccessor()
        {
            this.DoSomethingSpecific()
        }
        
        // need this to satisfy the abstract class
        protected override void DoSomethingSpecific()
        {
            // do nothing here
        }
    }
