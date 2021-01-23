    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    namespace ConsoleApplication2
    {
        class Test2
        {
            public bool BoolProp { get; set; }
            public int[] ArrayProp { get; set; }
        }
        class Test1
        {
            public string StringProp { get; set; }
            public Dictionary<string, Test2> DictionaryProp { get; set; }
        }
        class Program
        {
        
            private static string ObjToPathKey(object key)
            {
                if (key == null) return "null";
                if (key is string) return string.Format("\"{0}\"", key);
                return key.ToString();
            }
            public static IEnumerable<KeyValuePair<string, object>> GetFullTree(object root, string currentPath)
            {
                if (root == null) yield break;
                yield return new KeyValuePair<string, object>(currentPath, root);
                var type = root.GetType();
                if (!type.IsClass || type == typeof(string)) yield break;
            
                if (root is IEnumerable)
                {
                    if (root is IDictionary)
                    {
                        IDictionary d = (IDictionary) root;
                        foreach (var key in d.Keys)
                        {
                            var child = d[key];
                            foreach (var subchildPair in GetFullTree(child, string.Format("{0}[{1}]", currentPath, ObjToPathKey(key))))
                            {
                                yield return subchildPair;
                            }
                        }
                        yield break;
                    }
                    int i = 0;
                    if (root is IList)
                    {
                        foreach (var child in (IEnumerable)root)
                        {
                            foreach (var subChildPair in GetFullTree(child, string.Format("{0}[{1}]", currentPath, i)))
                            {
                                yield return subChildPair;
                            }
                            ++i;
                        }
                        yield break;
                    }
                    throw new NotSupportedException();
                }
                if (type.IsClass)
                {
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        //TODO: Add indexers support
                        object propertyValue = propertyInfo.GetValue(root, null);
                        foreach (var subChildPair in GetFullTree(propertyValue, string.Format("{0}.{1}", currentPath, propertyInfo.Name)))
                        {
                            yield return subChildPair;
                        }
                    }
                }
            }
            static void Main(string[] args)
            {
                Test1 t = new Test1()
                              {
                                  StringProp = "Some value",
                                  DictionaryProp = new Dictionary<string, Test2>()
                                                       {
                                                           {
                                                               "key1", new Test2()
                                                                           {
                                                                               ArrayProp = new[] {1, 2, 3},
                                                                               BoolProp = true
                                                                           }
                                                               },
                                                           {
                                                               "key 2", new Test2()
                                                                            {
                                                                                ArrayProp = new[] {4, 5, 6, 7},
                                                                                BoolProp = false
                                                                            }
                                                               }
                                                       }
                              };
                foreach (var pair in GetFullTree(t, "t"))
                {
                    Console.WriteLine("{0} = {1}", pair.Key, pair.Value);
                }
                Console.Read();
                /* Program output:
                    t = ConsoleApplication2.Test1
                    t.StringProp = Some value
                    t.DictionaryProp = System.Collections.Generic.Dictionary`2[System.String,Console
                    Application2.Test2]
                    t.DictionaryProp["key1"] = ConsoleApplication2.Test2
                    t.DictionaryProp["key1"].BoolProp = True
                    t.DictionaryProp["key1"].ArrayProp = System.Int32[]
                    t.DictionaryProp["key1"].ArrayProp[0] = 1
                    t.DictionaryProp["key1"].ArrayProp[1] = 2
                    t.DictionaryProp["key1"].ArrayProp[2] = 3
                    t.DictionaryProp["key 2"] = ConsoleApplication2.Test2
                    t.DictionaryProp["key 2"].BoolProp = False
                    t.DictionaryProp["key 2"].ArrayProp = System.Int32[]
                    t.DictionaryProp["key 2"].ArrayProp[0] = 4
                    t.DictionaryProp["key 2"].ArrayProp[1] = 5
                    t.DictionaryProp["key 2"].ArrayProp[2] = 6
                    t.DictionaryProp["key 2"].ArrayProp[3] = 7
                 */
            }
        }
    }
