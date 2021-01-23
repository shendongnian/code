    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    
    [assembly: InternalsVisibleTo("Program.XmlSerializers")]
    
    namespace InternalTypesInXmlSerializer
    {
        class Program
        {
            static void Main(string[] args)
            {
                Address address = new Address();
                address.Street = "One Microsoft Way";
                address.City = "Redmond";
                address.Zip = 98053;
                Order order = new Order();
                order.BillTo = address;
                order.ShipTo = address;
     
                XmlSerializer xmlSerializer = GetSerializer(typeof(Order));
                xmlSerializer.Serialize(Console.Out, order);
            }
    
            static XmlSerializer GetSerializer(Type type)
            {
    #if Pass1
                return new XmlSerializer(type);
    #else
                Assembly serializersDll = Assembly.Load("Program.XmlSerializers");
                Type xmlSerializerFactoryType = serializersDll.GetType("Microsoft.Xml.Serialization.GeneratedAssembly.XmlSerializerContract");
    
                MethodInfo getSerializerMethod = xmlSerializerFactoryType.GetMethod("GetSerializer", BindingFlags.Public | BindingFlags.Instance);
    
                return (XmlSerializer)getSerializerMethod.Invoke(Activator.CreateInstance(xmlSerializerFactoryType), new object[] { type });
    
    #endif
            }
        }
    
    #if Pass1
        public class Address
    #else
        internal class Address
    #endif
        {
            public string Street;
            public string City;
            public int Zip;
        }
    
    #if Pass1
        public class Order
    #else
        internal class Order
    #endif
        {
            public Address ShipTo;
            public Address BillTo;
        }
    } 
