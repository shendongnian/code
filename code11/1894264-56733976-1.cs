	public class details
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public string[] ToArr()
        {
            List<string> list = new List<string> { Id.ToString(), Name, Address, Country, Phone.ToString() };
            return list.ToArray();
        }
    }
