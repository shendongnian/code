    public class StaticRef {
        static StaticRef() {
            Elementi = new ObservableCollection<element>();
        }
        public static ObservableCollection<element> Elementi {get; set;}
    }
