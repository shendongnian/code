    public class Validation_Element
    {
        public string Id { get; set; }
        public int Time { get; set; }
    }
    public class Custom_Time_Model
    {
        public Custom_Time_Model(int time)
        {
            Time = time;
            // This makes it possible to create classes where `Time` is different
            // but fullDate.Date (in the Add method) is the same. If I want that date
            // to be different I'll add 24 or more hours.
            RegularTime = new DateTime(2000,1,1).AddHours(time);
        }
        public DateTime RegularTime { get; set; }
        public int Time { get; set; }
    }
    public class Info_Model { }
