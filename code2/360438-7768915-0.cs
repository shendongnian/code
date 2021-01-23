    public static class PageTypes {
        public static PageType Admin(/** stuff here */);
        public static PageType User(/** stuff here */);
    }
    
    public class PageType {
        readonly string _backgroundColor;
        public PageType (/** stuff here */) {
            _backgroundColor = backgroundColor;
        }
        public string BackgroundColor {
            get {
                return _backgroundColor;
            }
    }
