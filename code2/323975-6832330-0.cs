    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class FrameClass
    {
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int x;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int y;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int w;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int h;
    }
    
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class SourceSizeClass
    {
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int w;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int h;
    }
    
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class But_01_Highlight_pngClass
    {
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FrameClass frame;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool rotated;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool trimmed;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FrameClass spriteSourceSize;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SourceSizeClass sourceSize;
    }
    
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class FramesClass
    {
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public But_01_Highlight_pngClass But_01_Highlight.png;
    }
    
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class RootClass
    {
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FramesClass frames;
    }
