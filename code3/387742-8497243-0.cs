      [XmlRoot("DataSet")]
      public class AddListCallHolder
      {
          [XmlArrayItem(typeof(BaseAttributeHolder), ElementName = "DATA")]
          public BaseAttributeHolder[] data 
          { 
               get;
               set;
          }
      
          [XmlIgnore]
          public BaseAttributeHolder Name
          {
              get
              {
                 return data.FirstOrDefault(d => d.Type == "name");
              }
          }
      
          [XmlIgnore]
          public BaseAttributeHolder CLICKTHRU_URL
          {
              get
      	      {
      	         return data.FirstOrDefault(d => d.Type == "extra" && d.Id == "CLICKTHRU_URL");
       	      }
          }
      }
