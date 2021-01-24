cs
   public interface IBuilderY
   {
      IBuilderZ DoY();
   }
   public interface IBuilderZ
   {
      void DoZ();
   }
   public class Builder : IBuilderY, IBuilderZ
   {
      
      public IBuilderY DoX()
      {
         return this;
      }
      public IBuilderZ DoY()
      {
         return this;
      }
      public void DoZ()
      {
      }
   }
in this example I can do `builder.DoX().DoY().DoZ()`, but not `builder.DoX().DoZ()`. Might not be required for your scenario, but handy to know...
