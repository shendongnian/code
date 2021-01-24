    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Reflection;
    namespace RosterNS
    {
        using IRoster = IDictionary<string, string>;
        [DataContract]
        public class RosterItem
        {
            [DataMember]
            public string code { get; set; }
            [DataMember]
            public string description { get; set; }
        }
        public class Rosters
        {
            static private Dictionary<string, IRoster> rosters = new Dictionary<string, IRoster>();
            public static IRoster RegisterRoster(string category)
            {
                IRoster roster;
                if (!rosters.TryGetValue(category, out roster))
                {
                    roster = new Dictionary<string, string>();
                    rosters.Add(category, roster);
                }
                return roster;
            }
    #if DEBUG
            public static void ListRosters()
            {
                foreach(KeyValuePair<string, IRoster> kvp in rosters)
                {
                    Console.WriteLine("Category:{0}", kvp.Key.ToString());
                    foreach (KeyValuePair<string, string> skvp in kvp.Value)
                        Console.WriteLine("\t{0:20}==>{1}", skvp.Key, skvp.Value);
                }
            }
    #endif
        }
        [AttributeUsage(AttributeTargets.Property)]
        public class RosterCategoryAttribute : Attribute
        {
            private IRoster roster;
            public string Category { get; protected set; }
            public RosterCategoryAttribute(string category)
            {
                Category = category;
                roster = Rosters.RegisterRoster(category);
            }
            public void addToRoster(RosterItem item)
            {
                if (item != null && !roster.ContainsKey(item.code))
                    roster.Add(item.code, item.description);
            }
        }
        [DataContract]
        public class RosterResult
        {
            //The only implementation that save the RosterItem into categorized Roster
            [OnDeserialized]
            public void OnDeserialized(StreamingContext sc)
            {
                PropertyInfo[] properties = GetType().GetProperties();
                foreach (PropertyInfo info in properties)
                {
                    RosterCategoryAttribute attr = info.GetCustomAttribute<RosterCategoryAttribute>();
                    if (attr != null)
                        attr.addToRoster(info.GetValue(this) as RosterItem);
                }
            }
        }
    }
