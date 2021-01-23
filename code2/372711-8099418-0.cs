    public class KMLDocument
    {
       public List<KMLObject> members = new List<KMLObject>();
       public void AddPlacemark(string p, string v)
       {
          members.Add(new Placemark(p, v));
       }
       public void AddFeature()
       {
          members.Add(new Feature());
       }
    }
    public class KMLObject { }
    public class Feature : KMLObject { }
    public class Placemark : Feature
    {
       public string p;
       public string v;
       public Placemark() { }
       public Placemark(string p1, string v1) { p = p1; v = v1; }
    }
