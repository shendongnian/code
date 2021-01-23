    public enum NSystem { A = 0, B = 1, C = 2 }
    [Serializable]
    [XmlRoot(ElementName = "A")]
    Class A 
    {
     //Few Properties of Class A
     [XmlArrayItem("ListOfB")]
     List<B> list1;
    
     [XmlArrayItem("ListOfC")]
     List<C> list2;
    
     NSystem NotSystem { get; set; } 
    }
