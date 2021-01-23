    class Address
    {
       public int Type_ID { get; set; }
       public Address(int Type_ID)
       {
          this.Type_ID = Type_ID;
       }
    }
    class Entry
    {
       public List<Address> AddressList { get; set; }
       public string UserName { get; set; }
       public Entry(string name, List<Address> addresses)
       {
          AddressList = addresses;
          this.UserName = name;
       }
    }
    class EntryList
    {
       private List<Entry> entries;
       public IEnumerable<Entry> GetAll(Func<Entry, bool> filter)
       {
          return entries.Where(filter).ToArray();
       }
       public EntryList(List<Entry> entries)
       {
          this.entries = entries;
       }
    }
    static void Main(string[] args)
    {
       EntryList e1 = new EntryList(new List<Entry>()
          {new Entry("Fred with 1 98 address", new List<Address> { new Address(97), new Address(98) }),
             new Entry("Bob with no 98 address", new List<Address> { new Address(96), new Address(97) }),
             new Entry("Jerry with all 98 addresses", new List<Address> { new Address(98), new Address(98) })});
       var all98 = e1.GetAll(x => x.AddressList.All(y => y.Type_ID == 98));
       var any98 = e1.GetAll(x => x.AddressList.Any(y => y.Type_ID == 98));
       Console.WriteLine("Results for ALL:");
       foreach (var e in all98)
          Console.WriteLine(e.UserName);
       Console.WriteLine("Results for ANY:");
       foreach (var e in any98)
          Console.WriteLine(e.UserName);
    }
