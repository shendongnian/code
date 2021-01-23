    namespace Version1
    {
        public interface IOpenDefectService
        {
            void Submit(string title, string description, int severity);
            void Bump(int issueId);
        }
    }
    namespace Version2
    {
        public interface IOpenDefectService
        {
            void Submit(string title, string description, int severity);
            // Removed Bump method - it was a bad idea
            // Added an optional priority field
            void Submit(string title, string description, int severity,
                int priority);
            // Added support for deleting 
            void Delete(int id);
        }
    }
    public class OpenDefectService : Version1.IOpenDefectService,
        Version2.IOpenDefectService
    {
        // Still must support it until you no longer have any clients using it.
        // Here to support staggered rollouts
        [Obsolete("This method is deprecated.  Don't use it")]
        public void Bump(int issueId) { }
        public void Submit(string title, string description, int severity) { }
        public void Submit(string title, string description, int severity,
            int priority)
        {
        }
        public void Delete(int id) { }
    }
