        public class MassMailViewModel
    {
        public string ContactIdsString { get; set; }//TODO I'd like to not have to do this.
        public IEnumerable<int> ContactIds => this.ContactIdsString.Split(',').Select(n => int.Parse(n));
    }
