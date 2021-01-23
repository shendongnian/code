    public struct PinInformation
    {
         private readonly string testBatch;
         private readonly string vIGroup;
         public PinInformation(string testBatch, string vIGroup)
         {
              this.testBatch = testBatch;
              this.vIGroup = vIGroup;
         }
         public string TestBatch { get { return this.testBatch; } }
         public string VIGroup { get { return this.vIGroup; } }
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
