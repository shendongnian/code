    public class A { public IDictionary<int, string> myDictionary = new Dictionary<int, string>(); }
    public class B { public IDictionary<int, string> myDictionary = new Dictionary<int, string>(); }
	class Program
    {
        static void Main(string[] args)
        {
            var instanceOfA = new A
                                  {
                                      myDictionary = new Dictionary<int, string>
                                                         {
                                                             {1, "a"},
                                                             {2, "b"}
                                                         }
                                  };
            Mapper.CreateMap<A, B>()
                .ForMember(d => d.myDictionary, opt => opt.ResolveUsing(
                  s => s.myDictionary.ToDictionary(pair => pair.Key, pair => pair.Value)));
            var instanceOfB = Mapper.Map<A, B>(instanceOfA);
            instanceOfA.myDictionary[1] = "c";
            if (instanceOfB.myDictionary[1] == "c")
                Console.WriteLine("Failed");
            else
                Console.WriteLine("Succeeded");
            Console.ReadLine();
        }
    }
