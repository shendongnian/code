    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json.Serialization;
    
    namespace MyNamespace
    {
        /// <summary>
        /// This class enables EntityFramework POCO objects to be serialized. In some cases POCO
        /// objects are subclassed by a proxy which has an additional member _entityWrapper. This
        /// object prevents serialization (circular references and references to non-serializable types).
        /// This removes the _entityWrapper from the list of members to be serialized.
        /// </summary>
        public class ContractResolver : CamelCasePropertyNamesContractResolver
        {
            protected override List<MemberInfo> GetSerializableMembers(Type objectType)
            {
                if (objectType.FullName.StartsWith("System.Data.Entity.DynamicProxies."))
                {
                    var members = base.GetSerializableMembers(objectType);
                    members.RemoveAll(memberInfo => memberInfo.Name == "_entityWrapper");
                    return members;
                }
                return base.GetSerializableMembers(objectType);
            }
        }
    }
