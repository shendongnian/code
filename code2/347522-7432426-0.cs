    public class PinInformation
    {
        
         private readonly List<string> ignoredPins;
         private readonly string testBatch;
         private readonly string vIGroup;
         public PinInformation(string testBatch, string vIGroup)
         {
              this.testBatch = testBatch;
              this.vIGroup = vIGroup;
              this.ignoredPins = new List<string>();
         }
         public string TestBatch { get { return this.testBatch; } }
         public string VIGroup { get { return this.vIGroup; } }
         public List<string> IgnoredPins
         {
              return this.ignoredPins;
         }
         public override bool Equals(object o)
         {
              if (o == null) return false;
              
              PinInformation info = o as PinInformation;
              
              if (info == null)
              {
                   return false;
              }
              else
              {
                   return (this.testBatch == info.testBatch) && (this.vIGroup == info.vIGroup);
              } 
              
         }
    }
