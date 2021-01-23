    namespace Server.Contracts.DataContracts.Mapped
    {
        using System;
        using System.Runtime.Serialization;
        [DataContract]
        public class ConfigSetting : BindableDataContract
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Value { get; set; }
            [DataMember]
            public DateTime ModifiedOn { get; set; }
            public override object Clone()
            {
                return new ConfigSetting
                       {
                           ModifiedOn = this.ModifiedOn,
                           Name = this.Name,
                           Value = this.Value,
                       };
            }
        }
    }
