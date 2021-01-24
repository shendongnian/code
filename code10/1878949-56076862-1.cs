    [Serializable]
    public sealed class MyData
    {
        [XmlAttribute("SampleID")]
        public int SampleId { get; set; }
        [XmlAttribute("IW")]
        public double WhateverThisIs1 { get; set; }
        [XmlAttribute("SL")]
        public double WhateverThisIs2 { get; set; }
        [XmlAttribute("PO")]
        public int WhateverThisIs3 { get; set; }
    }
