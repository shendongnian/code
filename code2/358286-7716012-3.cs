    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Dynamic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    namespace JsonUtils
    {
        class JsonObject : DynamicObject, IEnumerable, IEnumerator
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
            public override string ToString()
            {
                return _object.ToString();
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
                return _index < (_object as JArray).Count;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
