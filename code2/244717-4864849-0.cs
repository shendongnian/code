    public class FooView
    {
       public FooView(Row row)
       {
          this.Row = row;
       }
    
       private Row Row { get; set; }
        
       public string Server { get { (string)return this.Row["Server"]; } }
       public string Blah{ get { (string)return this.Row["blah"]; } }
       public string Link1{ get { string.Format("http://foo.bar/id={0}", this.Server); } }
    }
