    [XmlRoot(ElementName="response")]
    public class Response()
    {
      [XmlElement(ElementName="result")]
      private string ResultInternal { get; set; }
      public bool Result{
        get{
          return this.ResultInternal == "success";
        }
        set{
          this.ResultInternal = value ? "success" : "failure";
        }
      }
    }
