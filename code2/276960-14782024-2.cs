    using System;
    using System.Configuration;
     
    namespace SSHTunnelWF
    {
        public class TunnelSection : ConfigurationSection
        {
            [ConfigurationProperty("", IsDefaultCollection = true)]  
            public HostCollection Tunnels
            {
                get
                {
                    HostCollection hostCollection = (HostCollection)base[""];
                    return hostCollection;                
                }
            }
        }
     
        public class HostCollection : ConfigurationElementCollection
        {
            public HostCollection()
            {
                HostConfigElement details = (HostConfigElement)CreateNewElement();
                if (details.SSHServerHostname != "")
                {
                    Add(details);
                }
            }
     
            public override ConfigurationElementCollectionType CollectionType
            {
                get
                {
                    return ConfigurationElementCollectionType.BasicMap;
                }
            }
     
            protected override ConfigurationElement CreateNewElement()
            {
                return new HostConfigElement();
            }
     
            protected override Object GetElementKey(ConfigurationElement element)
            {
                return ((HostConfigElement)element).SSHServerHostname;
            }
     
            public HostConfigElement this[int index]
            {
                get
                {
                    return (HostConfigElement)BaseGet(index);
                }
                set
                {
                    if (BaseGet(index) != null)
                    {
                        BaseRemoveAt(index);
                    }
                    BaseAdd(index, value);
                }
            }
     
            new public HostConfigElement this[string name]
            {
                get
                {
                    return (HostConfigElement)BaseGet(name);
                }
            }
     
            public int IndexOf(HostConfigElement details)
            {
                return BaseIndexOf(details);
            }
     
            public void Add(HostConfigElement details)
            {
                BaseAdd(details);
            }
            protected override void BaseAdd(ConfigurationElement element)
            {
                BaseAdd(element, false);
            }
     
            public void Remove(HostConfigElement details)
            {
                if (BaseIndexOf(details) >= 0)
                    BaseRemove(details.SSHServerHostname);
            }
     
            public void RemoveAt(int index)
            {
                BaseRemoveAt(index);
            }
     
            public void Remove(string name)
            {
                BaseRemove(name);
            }
     
            public void Clear()
            {
                BaseClear();
            }
     
            protected override string ElementName
            {
                get { return "host"; }
            }
        }
     
        public class HostConfigElement:ConfigurationElement
        {
            [ConfigurationProperty("SSHServerHostname", IsRequired = true, IsKey = true)]
            [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
            public string SSHServerHostname
            {
                get { return (string)this["SSHServerHostname"]; }
                set { this["SSHServerHostname"] = value; }
            }
     
            [ConfigurationProperty("username", IsRequired = true)]
            [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
            public string Username
            {
                get { return (string)this["username"]; }
                set { this["username"] = value; }
            }
            [ConfigurationProperty("SSHport", IsRequired = true, DefaultValue = 22)]
            [IntegerValidator(MinValue = 1, MaxValue = 65536)]
            public int SSHPort
            {
                get { return (int)this["SSHport"]; }
                set { this["SSHport"] = value; }
            }
     
            [ConfigurationProperty("password", IsRequired = false)]
            public string Password
            {
                get { return (string)this["password"]; }
                set { this["password"] = value; }
            }
     
            [ConfigurationProperty("privatekey", IsRequired = false)]
            public string Privatekey
            {
                get { return (string)this["privatekey"]; }
                set { this["privatekey"] = value; }
            }
     
            [ConfigurationProperty("privatekeypassphrase", IsRequired = false)]
            public string Privatekeypassphrase
            {
                get { return (string)this["privatekeypassphrase"]; }
                set { this["privatekeypassphrase"] = value; }
            }
     
            [ConfigurationProperty("tunnels", IsDefaultCollection = false)]
            public TunnelCollection Tunnels
            {
                get { return (TunnelCollection)base["tunnels"]; }
            }
        }
     
        public class TunnelCollection : ConfigurationElementCollection
        {
            public new TunnelConfigElement this[string name]
            {
                get
                {
                    if (IndexOf(name) < 0) return null;
                    return (TunnelConfigElement)BaseGet(name);
                }
            }
     
            public TunnelConfigElement this[int index]
            {
                get { return (TunnelConfigElement)BaseGet(index); }
            }
     
            public int IndexOf(string name)
            {
                name = name.ToLower();
     
                for (int idx = 0; idx < base.Count; idx++)
                {
                    if (this[idx].Name.ToLower() == name)
                        return idx;
                }
                return -1;
            }
     
            public override ConfigurationElementCollectionType CollectionType
            {
                get { return ConfigurationElementCollectionType.BasicMap; }
            }
     
            protected override ConfigurationElement CreateNewElement()
            {
                return new TunnelConfigElement();
            }
     
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((TunnelConfigElement)element).Name;
            }
     
            protected override string ElementName
            {
                get { return "tunnel"; }
            }
        }
     
        public class TunnelConfigElement : ConfigurationElement
        {        
            public TunnelConfigElement()
            {
            }
     
            public TunnelConfigElement(string name, int localport, int remoteport, string destinationserver)
            {
                this.DestinationServer = destinationserver;
                this.RemotePort = remoteport;
                this.LocalPort = localport;            
                this.Name = name;
            }
     
            [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]       
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }        
     
            [ConfigurationProperty("localport", IsRequired = true, DefaultValue =1)]
            [IntegerValidator(MinValue = 1, MaxValue = 65536)]
            public int LocalPort
            {
                get { return (int)this["localport"]; }
                set { this["localport"] = value; }
            }
     
            [ConfigurationProperty("remoteport", IsRequired = true, DefaultValue =1)]
            [IntegerValidator(MinValue = 1, MaxValue = 65536)]
            public int RemotePort
            {
                get { return (int)this["remoteport"]; }
                set { this["remoteport"] = value; }
            }
     
            [ConfigurationProperty("destinationserver", IsRequired = true)]
            [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
            public string DestinationServer
            {
                get { return (string)this["destinationserver"]; }
                set { this["destinationserver"] = value; }
            }
        }
    }
