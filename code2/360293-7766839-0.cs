    public interface IDisplayErrorImplementation {
        void ShowErrorMessage(string message, Exception ex);
    }
    public class DefaultDisplayErrorImplementation : IDisplayErrorImplementation {
        public void ShowErrorMessage(string message, Exception ex) {
            //...
        }
    }
    public static class DisplayError {
        static DisplayError(){
            Implementation = new  DefaultDisplayErrorImplementation();
         }
        public static IDisplayErrorImplementation Implementation { get; set;}
        public static void ShowErrorMessage(string message, Exception ex) {
            Implementation.ShowErrorMessage(message, ex);
        }
    }
