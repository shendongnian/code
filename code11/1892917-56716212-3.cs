    // **Domain.dll**
    public enum ActivityType { Exam, Training }
    public interface IActivity {
        ActivityType Type { get; }
    }
    public interface IExam : IActivity { }
    internal class Exam : IExam { }
    public class ActivityFactory {
        public IExam CreateExam() { return new Exam(); }
        public ITraining CreateTraining() { return new Training(); }
        // other concrete activities
    }
