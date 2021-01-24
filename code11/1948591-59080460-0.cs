using System
using System.Reflection;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Car A = new Car
            {
                Make = "Volvo"
            };
            Car B = new Car
            {
                Year = 2001,
                CreateDate = DateTime.Now
            };
            Car C = new Car
            {
                ShortValue = 1,
                MSRP = 20000,
                ByteValue = 10
            };
            Car D = new Car();
            Mapper mapobj = new Mapper();
            D = mapobj.Map<Car, Car>(A);
            D = mapobj.Compare<Car, Car>(B, D);
            D = mapobj.Compare<Car, Car>(C, D);
        }
        public class Mapper
        {
            public U Map<T, U>(T data)
            {
                var _result = (U)Activator.CreateInstance(typeof(U), new object[] { });
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    if (typeof(U).GetProperty(propertyInfo.Name) != null)
                        typeof(U)
                            .GetProperty(propertyInfo.Name,
                                BindingFlags.IgnoreCase |
                                BindingFlags.Instance |
                                BindingFlags.Public)
                            .SetValue(_result,
                                propertyInfo.GetValue(data));
                }
                return _result;
            }
            public U Compare<T, U>(T data, T data2)
            {
                var _result = (U)Activator.CreateInstance(typeof(U), new object[] { });
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    if (typeof(T).GetProperty(propertyInfo.Name) != null)
                    {
                        bool isnullvalue = false;
                        DateTime zerodate = new DateTime();
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case "String":
                                if ((string)propertyInfo.GetValue(data) != null && (string)propertyInfo.GetValue(data2) == null)
                                    isnullvalue = true;
                                break;
                            case "Int32":
                                if ((Int32)propertyInfo.GetValue(data) != 0 && (Int32)propertyInfo.GetValue(data2) == 0)
                                    isnullvalue = true;
                                break;
                            case "Int16":
                                if ((Int16)propertyInfo.GetValue(data) != 0 && (Int16)propertyInfo.GetValue(data2) == 0)
                                    isnullvalue = true;
                                break;
                            case "Byte":
                                if ((Byte)propertyInfo.GetValue(data) != 0 && (Byte)propertyInfo.GetValue(data2) == 0)
                                    isnullvalue = true;
                                break;
                            case "Double":
                                if ((Double)propertyInfo.GetValue(data) != 0 && (Double)propertyInfo.GetValue(data2) == 0)
                                    isnullvalue = true;
                                break;
                            case "DateTime":  // DateTime.Compare(date1, date2)
                                DateTime time1 = (DateTime)propertyInfo.GetValue(data);
                                DateTime time2 = (DateTime)propertyInfo.GetValue(data2);
                                if (DateTime.Compare(time1, zerodate) != 0 && DateTime.Compare(time2, zerodate) == 0)
                                    isnullvalue = true;
                                break;
                            default:
                                Console.WriteLine("No handler for type {} found");
                                Console.ReadLine();
                                Environment.Exit(-1);
                                break;
                        }
                        if (isnullvalue)
                        {
                            typeof(U).GetProperty(propertyInfo.Name,
                                    BindingFlags.IgnoreCase |
                                    BindingFlags.Instance |
                                    BindingFlags.Public)
                                .SetValue(_result,
                                    propertyInfo.GetValue(data));
                        }
                        else
                        {
                            typeof(U).GetProperty(propertyInfo.Name,
                                    BindingFlags.IgnoreCase |
                                    BindingFlags.Instance |
                                    BindingFlags.Public)
                                .SetValue(_result,
                                    propertyInfo.GetValue(data2));
                        }
                    }
                }
                return _result;
            }
        }
        public class Car
        {
            public string Make { get; set; }
            public int Year { get; set; }
            public short ShortValue { get; set; }
            public byte ByteValue { get; set; }
            public DateTime CreateDate { get; set; }
            public double MSRP { get; set; }
        }
    }
}
