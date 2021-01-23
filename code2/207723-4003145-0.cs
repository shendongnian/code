    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace StringInterpolation {
        /// <summary>
        /// An object with an explicit, available-at-runtime name.
        /// </summary>
        public struct NamedObject {
            public string Name;
            public object Object;
    
            public NamedObject(string name, object obj) {
                Name = name;
                Object = obj;
            }
        }
    
        public static class StringInterpolation {
            /// <summary>
            /// Parses a string for basic Razor-like interpolation with explicitly passed objects.
            /// For example, pass a NamedObject user, and you can use @user and @user.SomeProperty in your string.
            /// </summary>
            /// <param name="s">The string to be parsed.</param>
            /// <param name="objects">A NamedObject array for objects too allow for parsing.</param>
            public static string Interpolate(this string s, params NamedObject[] objects) {
                System.Diagnostics.Debug.WriteLine(s);
    
                List<NamedObject> namedObjects = new List<NamedObject>(objects);
    
                Dictionary<NamedObject, Dictionary<string, string>> objectsWithProperties = new Dictionary<NamedObject, Dictionary<string, string>>();
    
                foreach (NamedObject no in objects) {
                    Dictionary<string, string> properties = new Dictionary<string, string>();
    
                    foreach (System.Reflection.PropertyInfo pInfo in no.Object.GetType().GetProperties())
                        properties.Add(pInfo.Name, pInfo.GetValue(no.Object, new object[] { }).ToString());
    
                    objectsWithProperties.Add(no, properties);
                }
    
                foreach (Match match in Regex.Matches(s, @"@(\w+)(\.(\w+))?")) {
                    NamedObject no;
                    no = namedObjects.Find(delegate(NamedObject n) { return n.Name == match.Groups[1].Value; });
    
                    if (no.Name != null && match.Groups.Count == 4)
                        if (string.IsNullOrEmpty(match.Groups[3].Value))
                            s = s.Replace(match.Value, no.Object.ToString());
                        else {
                            Dictionary<string, string> properties = null;
                            string value;
                            objectsWithProperties.TryGetValue(no, out properties);
    
                            if (properties != null && properties.TryGetValue(match.Groups[3].Value, out value))
                                s = s.Replace(match.Value, value);
                        }
    
                }
    
                return s;
            }
        }
    }
