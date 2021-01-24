    public class NonDefaultingBoard : BaseBoardNode
    {
        [JsonProperty(PropertyName = BaseNode._constKeyName_sNodeParentId, Required = Required.Always)]
        public override string _sNodeParentId { get => base._sNodeParentId; set => base._sNodeParentId = value; }
        [JsonProperty(PropertyName = BaseBoardNode._constKeyName_sNodeName, Required = Required.Always)]
        public override string _sNodeName { get => base._sNodeName; set => base._sNodeName = value; }
        [JsonProperty(PropertyName = BaseBoardNode._constKeyName_sNodeIP, Required = Required.Always)]
        public override string _sNodeIP { get => base._sNodeIP; set => base._sNodeIP = value; }
        [JsonProperty(PropertyName = BaseBoardNode._constKeyName_iNodePort, Required = Required.Always)]
        public override int _iNodePort { get => base._iNodePort; set => base._iNodePort = value; }
    }
