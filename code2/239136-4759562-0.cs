     using NHibernate.Event.Default
     public class MyCreatorListener : DefaultLoadEventListener
     {
       // this is the single method defined by the LoadEventListener interface
       public override void OnLoad(LoadEvent theEvent, LoadType loadType)
       {
         if(null == theEvent.InstanceToLoad) // Not null if user supplied object
         {
           theEvent.InstanceToLoad = MyFactory.Create(loadType); // Or whatever.
         }
       }
     }
