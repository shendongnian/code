     [Serializable]
    public partial class XmlBinDefinitionModel : ViewModelBase
    {
        [XmlElement("EqptID")]
        private string eqptID;
        public string EqptID
        {
            get { return eqptID; }
            set
            {
                if (eqptID != value)
                {
                    eqptID = value;
                    RaisePropertyChanged(nameof(EqptID));
                }
            }
        }
        [XmlElement("EquipOpn")]
        private string equipOpn;
        public string EquipOpn
        {
            get { return equipOpn; }
            set
            {
                if (equipOpn != value)
                {
                    equipOpn = value;
                    RaisePropertyChanged(nameof(EquipOpn));
                }
            }
        }
        private List<BinDefinitionModel> binDefinition;
        public List<BinDefinitionModel> BinDefinition
        {
            get { return binDefinition; }
            set
            {
                if (binDefinition != value)
                {
                    binDefinition = value;
                    RaisePropertyChanged(nameof(BinDefinition));
                }
            }
        }
    }//end public partial class XmlBinDefinitionModel 
    public partial class BinDefinitionModel : ViewModelBase
    {
        [XmlElement("BinCode")]
        private string binCode;
        public string BinCode
        {
            get { return binCode; }
            set
            {
                if (binCode != value)
                {
                    binCode = value;
                    RaisePropertyChanged(nameof(BinCode));
                }
            }
        }
        [XmlElement("BinDescription")]
        private string binDescription;
        public string BinDescription
        {
            get { return binDescription; }
            set
            {
                if (binDescription != value)
                {
                    binDescription = value;
                    RaisePropertyChanged(nameof(BinDescription));
                }
            }
        }
        [XmlElement("BinQuality")]
        private string binQuality;
        public string BinQuality
        {
            get { return binQuality; }
            set
            {
                if (binQuality != value)
                {
                    binQuality = value;
                    RaisePropertyChanged(nameof(BinQuality));
                }
            }
        }
        [XmlElement("Pick")]
        private string pick;
        public string Pick
        {
            get { return pick; }
            set
            {
                if (pick != value)
                {
                    pick = value;
                    RaisePropertyChanged(nameof(Pick));
                }
            }
        }
        [XmlElement("VisionStation")]
        private string visionStation;
        public string VisionStation
        {
            get { return visionStation; }
            set
            {
                if (visionStation != value)
                {
                    visionStation = value;
                    RaisePropertyChanged(nameof(VisionStation));
                }
            }
        }
        [XmlElement("VisionIO")]
        private string visionIO;
        public string VisionIO
        {
            get { return visionIO; }
            set
            {
                if (visionIO != value)
                {
                    visionIO = value;
                    RaisePropertyChanged(nameof(VisionIO));
                }
            }
        }
    }
   
    
