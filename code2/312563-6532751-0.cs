      public abstract class FlatScreenTV
      {
          public virtual void SetOptimumDisplay()
          {
             //do nothing - base class has no implementation here
          }
      }
      public class PhilipsWD20TV
      {
          public int BackLightIntensity {get;set;}
          
          public override void SetOptimumDisplay()
          {
              //Do Something that uses BackLightIntensity
          }
      }
