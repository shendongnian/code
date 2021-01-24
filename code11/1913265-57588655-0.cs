 c#
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
namespace Json
{
    static class P
    {
        static void Main()
        {
            var obj = new Sensors { IOPcwFlSpr = { Value = 42.5 }, Whatever = { Value = 9 } };
            foreach(var pair in SomeUtil.GetSensors(obj))
            {
                Console.WriteLine($"{pair.Name}: {pair.Value}");
            }
        }
    }
    public class Sensors
    {
        public JsonSensor<double> IOPcwFlSpr { get; set; } = new JsonSensor<double>();
        public JsonSensor<int> Whatever { get; set; } = new JsonSensor<int>();
    }
    public interface IJsonSensor
    {
        public string Value { get; }
    }
    public class JsonSensor<TType> : IJsonSensor
    {
        public TType Value { get; set; }
        string IJsonSensor.Value => Convert.ToString(Value);
    }
    public static class SomeUtil
    {
        private static readonly (string name, Func<Sensors, IJsonSensor> accessor)[] s_accessors
            = Array.ConvertAll(
                typeof(Sensors).GetProperties(BindingFlags.Instance | BindingFlags.Public),
                prop => (prop.Name, Compile(prop)));
        public static IEnumerable<(string Name, string Value)> GetSensors(Sensors obj)
        {
            foreach (var acc in s_accessors)
                yield return (acc.name, acc.accessor(obj).Value);
        }
        private static Func<Sensors, IJsonSensor> Compile(PropertyInfo property)
        {
            var parameterExpression = Expression.Parameter(typeof(Json.Sensors), "x");
            Expression body = Expression.Property(parameterExpression, property);
            body = Expression.Convert(body, typeof(IJsonSensor));
            var lambda = Expression.Lambda<Func<Json.Sensors, IJsonSensor>>(body, parameterExpression);
            return lambda.Compile();
        }
    }
}
