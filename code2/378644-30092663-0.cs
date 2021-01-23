    namespace Serialization
    {
        using System;
        using System.Collections.Generic;
        using System.Dynamic;
        using System.Linq;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        public static class JsonSerializer
        {
            #region Public Methods
            public static string Serialize(dynamic obj)
            {
                return JsonConvert.SerializeObject(obj);
            }
            public static dynamic Deserialize(string s)
            {
                var obj = JsonConvert.DeserializeObject(s);
                return obj is string ? obj as string : Deserialize((JToken)obj);
            }
            #endregion
            #region Methods
            private static dynamic Deserialize(JToken token)
            {
                // FROM : http://blog.petegoo.com/archive/2009/10/27/using-json.net-to-eval-json-into-a-dynamic-variable-in.aspx
                // Ideally in the future Json.Net will support dynamic and this can be eliminated.
                if (token is JValue)
                {
                    var value = ((JValue)token).Value;
                    if (value is Int64)
                    {
                        var lValue = (Int64)value;
                        if (Int32.MinValue <= lValue && lValue <= 0 || 0 < lValue && lValue <= Int32.MaxValue)
                        {
                            var iValue = (Int32)lValue;
                            value = iValue;
                            // Take out this if you don't want to cast down to Int16.
                            if (Int16.MinValue <= iValue && iValue <= 0 || 0 < iValue && iValue <= Int16.MaxValue)
                            {
                                value = (Int16)iValue;
                            }
                        }
                    }
                    return value;
                }
                if (token is JObject)
                {
                    var expando = new ExpandoObject();
                    (from childToken in token
                     where childToken is JProperty
                     select childToken as JProperty).ToList().
                        ForEach(property => ((IDictionary<string, object>)expando).Add(property.Name, Deserialize(property.Value)));
                    return expando;
                }
                if (token is JArray)
                {
                    var items = new List<object>();
                    foreach (var arrayItem in ((JArray)token)) items.Add(Deserialize(arrayItem));
                    return items;
                }
                throw new ArgumentException(string.Format("Unknown token type '{0}'", token.GetType()), "token");
            }
            #endregion
        }
    }
    namespace Serialization.Tests
    {
        public class JsonSerializerTests
        {
            [Test]
            public void ShouldDeserializeAsInt16([Values(0, Int16.MaxValue, Int16.MinValue)] Int16 x)
            {
                var json = string.Format("{{ x: {0} }}", x);
                var dynamic = JsonSerializer.Deserialize(json);
                Assert.That(dynamic.x.GetType(), Is.EqualTo(typeof(Int16)));
            }
            [Test]
            public void ShouldDeserializeAsInt32([Values(Int16.MaxValue + 1, Int16.MinValue - 1)] Int32 x)
            {
                var json = string.Format("{{ x: {0} }}", x);
                var dynamic = JsonSerializer.Deserialize(json);
                Assert.That(dynamic.x.GetType(), Is.EqualTo(typeof(Int32)));
            }
            [Test]
            public void ShouldDeserializeAsInt64([Values(Int32.MaxValue + 1L, Int32.MinValue - 1L)] Int64 x)
            {
                var json = string.Format("{{ x: {0} }}", x);
                var dynamic = JsonSerializer.Deserialize(json);
                Assert.That(dynamic.x.GetType(), Is.EqualTo(typeof(Int64)));
            }
        }
    }
