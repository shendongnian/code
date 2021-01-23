     public interface ITask
     {
        public void Schedule( DateTime startDate );
     }
     public abstract class TaskBase : ITask
     {
        // common methods...
        public abstract void Schedule( DateTime startDate );
     }
     public class WeeklyTask : TaskBase
     {
        public override void Schedule( DateTime startDate )
        {
             var startWeek = GetStartOfWeek( startDate );
             var firstDate = startWeek.AddDays( DaysOfWeek[0] );
             ...
        }
     }
