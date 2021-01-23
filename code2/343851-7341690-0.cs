    [DataContract, Serializable]
    public class CollaborationEventMeasureDistance : CollaborationEvent  
    {  
        [DataMember]
        public Geometry Geometry { get; set; }  
    } 
    
    [KnownType(typeof(CollaborationEventMeasureDistance))] 
    [DataContract, Serializable]
    public partial class CollaborationEvent 
    { 
        [DataMember]
        public bool HasBeenTransported { get; set; } 
        [DataMember]
        public Guid MessageBoxGuid { get; set; }  
     
        public CollaborationEvent() 
        { 
            HasBeenTransported = false; 
        } 
     
    } 
