    public enum ActivityType { Exam, Trainig, Project, Task }
    public class Activity {
        public Guid ID { get; private set; }
        public abstract ActivityType Type { get; }
        // other stuff
    }
    public class Exam : Activity {
        public override ActivityType Type {
            get { return ActivityType.Exam; }
        }
        // other stuff
    }
    public class SomeClass {
        public void SomeAction(Activity activity) {
            if(activity.Type == ActivityType.Exam) {
                var examActivity = (Exam)activity;
                // do something with examActivity
            }
        }
    }
