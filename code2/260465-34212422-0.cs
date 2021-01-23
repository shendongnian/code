        return JsonConvert.SerializeObject(oModel, new JsonSerializerSettings() { ContractResolver = new DNSConfigurationModel.DNSConfigSerializer() });
        /// <summary>
        /// Helper class to ensure that we do not serialize the domainAdvancedDNS child objects 
        /// (we will create our own child collections for serialization). We also suppress serialization of the key ID's.
        /// </summary>
        public class DNSConfigSerializer : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
                return (from p in properties
                        where p.PropertyName != "DomainAdvancedDNS" &&
                              p.PropertyName != "domainAdvancedDNSSRVs" &&
                              !(p.DeclaringType.Name == "DomainAdvancedDN" && p.PropertyName == "domainAdvancedDNSConfigID") &&
                              p.PropertyName != "DomainAdvancedDNSID" &&
                              p.PropertyName != "domainAdvancedDNSSRVID"
                        select p).ToList();
            }
        }
