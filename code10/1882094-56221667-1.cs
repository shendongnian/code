    internal class WeekValues : INotifyPropertyChanged
    {
        public bool Monday { get {... } set { ...} }
        public bool Tuesday { get {... } set { ...} }
        public bool Wednesday { get {... } set { ...} }
        public bool Thursday { get {... } set { ...} }
        public bool Friday { get {... } set { ...} }
        public bool Saturday { get {... } set { ...} }
        public bool Sunday{ get {... } set { ...} }
    
        ...
    }
    internal class MyViewModel : INotifyPropertyChanged
    {
        public WeekValues Prise1 { get {... } set { ...} }
        public WeekValues Prise2 { get {... } set { ...} }
        public WeekValues Prise3 { get {... } set { ...} }
        public WeekValues Duree { get {... } set { ...} }
    
        ...
    }
