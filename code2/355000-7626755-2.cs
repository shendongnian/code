    using System;
    using System.Dynamic;
    using System.Collections;
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
            Console.WriteLine(json.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso.Length);
            Console.WriteLine(json.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso[1]);
            foreach (var x in json.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
    }
    class JsonObject : DynamicObject,IEnumerable,IEnumerator
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
            
            if (_object is JArray && binder.Name == "Length")
            {
                result = (_object as JArray).Count;
                return true;
            }
            
            JObject jObject = _object as JObject;
            object obj = jObject.SelectToken(binder.Name);
            if (obj is JValue)
                result = ((JValue)obj).ToString();
            else
                result = new JsonObject(jObject.SelectToken(binder.Name));
            return true;
        }
        int _index = -1;
        public IEnumerator GetEnumerator()
        {
            _index = -1;
            return this;
        }
        public object Current
        {
            get 
            {
                if (!(_object is JArray)) return null;
                object obj = (_object as JArray)[_index];
                if (obj is JValue) return ((JValue)obj).ToString();
                return obj;
            }
        }
        public bool MoveNext()
        {
            if (!(_object is JArray)) return false;
            _index++;
            return _index <(_object as JArray).Count;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
