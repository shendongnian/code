      [Serializable]
      [DataContract(Namespace = Utils.DataNamespace)]
      public class Detail 
      {
	    [DataMember(Order = 1)] 
		public string LineNbr { get; set; }
		[DataMember(Order = 2)]
		public string UPC { get; set; }
		[DataMember(Order = 3)] 
		public string SkuNbr { get; set; }
     }
