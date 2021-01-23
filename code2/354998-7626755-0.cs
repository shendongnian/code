    using System;
    using System.Dynamic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class JSonTest 
    {
        public static void Main()
        {
            string jsonStr = @"
                { 
                    'glossary': { 
                        'title': 'example glossary', 
                        'GlossDiv': { 
                            'title': 'S', 
                            'GlossList': { 
                                'GlossEntry': { 
                                    'ID': 'SGML', 
                                    'SortAs': 'SGML', 
                                    'GlossTerm': 'Standard Generalized Markup Language', 
                                    'Acronym': 'SGML', 
                                    'Abbrev': 'ISO 8879:1986', 
                                    'GlossDef': { 
                                        'para': 'A meta-markup language, used to create markup languages such as DocBook.', 
                                        'GlossSeeAlso': ['GML','XML'] 
                                    }, 
                                    'GlossSee': 'markup' 
                                } 
                            } 
                        } 
                    } 
                }
            ";
            JObject o = (JObject)JsonConvert.DeserializeObject(jsonStr);
            dynamic json = new JsonObject(o);
            Console.WriteLine(json.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso[1]);
        }
    }
    class JsonObject : DynamicObject
    {
        object _object;
        public JsonObject(object jObject)
        {
            this._object = jObject;
        }
        public object this[int i]
        {
            get
            {
                if (!(_object is JArray)) return null;
                object obj = (_object as JArray)[i];
                if (obj is JValue)
                {
                    return ((JValue)obj).ToString();
                }
                return new JsonObject(obj);
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            JObject jObject = _object as JObject;
            object obj = jObject.SelectToken(binder.Name);
            if (obj is JValue)
                result = ((JValue)obj).ToString();
            else
                result = new JsonObject(jObject.SelectToken(binder.Name));
            return true;
        }
    }
