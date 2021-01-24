    [XmlRoot(ElementName = "properties", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public class Properties
        {
            [XmlElement(ElementName = "Guid", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string Guid { get; set; }
            [XmlElement(ElementName = "ObjectId", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ObjectId { get; set; }
            [XmlElement(ElementName = "ProcessType", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ProcessType { get; set; }
            [XmlElement(ElementName = "ProcessTypeTxt", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ProcessTypeTxt { get; set; }
            [XmlElement(ElementName = "Description", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string Description { get; set; }
            [XmlElement(ElementName = "IntroText", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string IntroText { get; set; }
            [XmlElement(ElementName = "CreatedAtDateFormatted", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string CreatedAtDateFormatted { get; set; }
            [XmlElement(ElementName = "ChangedAtDateFormatted", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ChangedAtDateFormatted { get; set; }
            [XmlElement(ElementName = "PostingDate", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string PostingDate { get; set; }
            [XmlElement(ElementName = "ChangedAtDate", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ChangedAtDate { get; set; }
            [XmlElement(ElementName = "Priority", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string Priority { get; set; }
            [XmlElement(ElementName = "PriorityTxt", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string PriorityTxt { get; set; }
            [XmlElement(ElementName = "PriorityState", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string PriorityState { get; set; }
            [XmlElement(ElementName = "Concatstatuser", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string Concatstatuser { get; set; }
            [XmlElement(ElementName = "ActionRequired", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ActionRequired { get; set; }
            [XmlElement(ElementName = "StillOpen", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string StillOpen { get; set; }
            [XmlElement(ElementName = "Icon", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string Icon { get; set; }
            [XmlElement(ElementName = "SoldToPartyName", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string SoldToPartyName { get; set; }
            [XmlElement(ElementName = "ServiceTeamName", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ServiceTeamName { get; set; }
            [XmlElement(ElementName = "PersonRespName", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string PersonRespName { get; set; }
            [XmlElement(ElementName = "ConfigItemTxt", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
            public string ConfigItemTxt { get; set; }
            [XmlAttribute(AttributeName = "m", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string M { get; set; }
            [XmlAttribute(AttributeName = "d", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string D { get; set; }
        }
    
        [XmlRoot(ElementName = "content")]
        public class Content
        {
            [XmlElement(ElementName = "properties", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
            public Properties Properties { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }
