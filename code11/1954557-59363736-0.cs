public class Member: IEnumerable<string>
    {
        public Dictionary<string, string> variables = new Dictionary<string, string>();
        public Member()
        {
            //list of variables
            this.variables = new Dictionary<string, string>();
        }
        public IEnumerator<string> GetEnumerator()
        {
            return this.variables.Keys.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            //forces use of the non-generic implementation on the Values collection
            return ((IEnumerable)variables.Keys).GetEnumerator();
        }  
    }
}
Thanks for your help.
