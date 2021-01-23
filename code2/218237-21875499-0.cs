    using System.DirectoryServices;
    public static class Methods
    {
        public static T ldap_get_value<T>(PropertyValueCollection property)
        {
            object value = null;
            foreach (object tmpValue in property) value = tmpValue;
            return (T)value;
        }
        public static string ldap_get_domainname(DirectoryEntry entry)
        {
            if (entry == null || entry.Parent == null) return null;
            using (DirectoryEntry parent = entry.Parent)
            {
                if (ldap_get_value<string>(parent.Properties["objectClass"]) == "domainDNS") 
                    return ldap_get_value<string>(parent.Properties["dc"]);
                else 
                    return ldap_get_domainname(parent);
            }
        }
    }
