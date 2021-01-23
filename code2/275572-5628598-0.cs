    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Dynamic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    namespace YourFavoriteNamespace
    {
        public class JPerson
        {
            public string FNAME;
            public string LNAME;
            public BodyType bodyType;
            public JObject belongings;
            public JObject signs;
        }
        public class Person
        {
            public string FNAME;
            public string LNAME;
            public BodyType bodyType;
            public ExpandoObject belongings;
            public ExpandoObject signs;
        }
        public class BodyType
        {
            public int height;
            public int weight;
            public string race;
            public string hair;
        }
        class Program
        {
            static void DumpDynamic(dynamic d)
            {
                IDictionary<string, object> dynMap = (IDictionary<string, object>)d;
                foreach (string key in dynMap.Keys)
                {
                    Console.WriteLine("  {0}={1} (type {2})", key, dynMap[key], null == dynMap[key] ? "null" : dynMap[key].GetType().Name);
                }
            }
            static void DumpJProperties(JObject jo)
            {
                var props = jo.Properties();
                foreach (JProperty prop in props)
                {
                    Console.WriteLine("  {0}={1} (type {2})", prop.Name, prop.Value, null == prop.Value ? "null" : prop.Value.GetType().Name);
                }
            }
            static void DumpPerson(Person p)
            {
                Console.WriteLine("Person");
                Console.WriteLine("  FNAME={0}", p.FNAME);
                Console.WriteLine("  LNAME={0}", p.LNAME);
                Console.WriteLine("Person.BodyType");
                Console.WriteLine("  height={0}", p.bodyType.height);
                Console.WriteLine("  weight={0}", p.bodyType.weight);
                Console.WriteLine("  race  ={0}", p.bodyType.race);
                Console.WriteLine("  hair  ={0}", p.bodyType.hair);
                Console.WriteLine("Person.belongings");
                DumpDynamic(p.belongings);
                Console.WriteLine("Person.signs");
                DumpDynamic(p.signs);
            }
            static void DumpJPerson(JPerson p)
            {
                Console.WriteLine("Person");
                Console.WriteLine("  FNAME={0}", p.FNAME);
                Console.WriteLine("  LNAME={0}", p.LNAME);
                Console.WriteLine("Person.BodyType");
                Console.WriteLine("  height={0}", p.bodyType.height);
                Console.WriteLine("  weight={0}", p.bodyType.weight);
                Console.WriteLine("  race  ={0}", p.bodyType.race);
                Console.WriteLine("  hair  ={0}", p.bodyType.hair);
                Console.WriteLine("Person.belongings");
                DumpJProperties(p.belongings);
                Console.WriteLine("Person.signs");
                DumpJProperties(p.signs);
            }
            static void DoSimplePerson()
            {
                string initJson = "{\"FNAME\":\"joe\",\"LNAME\":\"doe\",\"BodyType\":{\"height\":180,\"weight\":\"200\",\"race\":\"white\",\"hair\":\"black\"},\"BELONGINGS\":{\"shirt\":\"black\",\"Money\":15,\"randomThing\":\"anyvar\"},\"Signs\":{\"tattoo\":0,\"scar\":\"forehead\",\"glasses\":\"dorky\"}}";
                Person p = JsonConvert.DeserializeObject<Person>(initJson);
                DumpPerson(p);
                Console.ReadLine();
            }
            static void DoComplexPerson()
            {
                string initJson = "{\"FNAME\":\"joe\",\"LNAME\":\"doe\",\"BodyType\":{\"height\":180,\"weight\":\"200\",\"race\":\"white\",\"hair\":\"black\"},\"BELONGINGS\":{\"shirt\":\"black\",\"Money\":15,\"randomThing\":\"anyvar\"},\"Signs\":{\"tattoo\":0,\"scar\":\"forehead\",\"glasses\":[\"dorky\",\"hipster\"]}}";
                Person p = JsonConvert.DeserializeObject<Person>(initJson);
                DumpPerson(p);
                Console.ReadLine();
            }
            static void DoJPerson()
            {
                string initJson = "{\"FNAME\":\"joe\",\"LNAME\":\"doe\",\"BodyType\":{\"height\":180,\"weight\":\"200\",\"race\":\"white\",\"hair\":\"black\"},\"BELONGINGS\":{\"shirt\":\"black\",\"Money\":15,\"randomThing\":\"anyvar\"},\"Signs\":{\"tattoo\":0,\"scar\":\"forehead\",\"glasses\":\"dorky\"}}";
                JPerson p = JsonConvert.DeserializeObject<JPerson>(initJson);
                DumpJPerson(p);
                Console.ReadLine();
            }
            static void Main(string[] args)
            {
                DoSimplePerson();
                DoComplexPerson();
                DoJPerson();
            }
        }
    }
