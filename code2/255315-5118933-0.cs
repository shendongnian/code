    public class YourObject()
    {
    public IEnumerable<Layer> Layers { get; set; }
    public int Id { get; set; }
         public YourObj(XElement x)
         {
            this.Id = int.Parse(x.Attribute("Id").ToString());
            this.Layers = from layer in x.Elements("Layer") 
                      select new Layer(layer);
         }
    }
    var objs = (from c in XElement.Load("your.xml").Elements("layer") 
              select new YourObject(c)).ToList() ;
