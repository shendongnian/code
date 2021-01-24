    public partial class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Stop { get; set; }
        public string Description { get; set; }
        public virtual Room Room{ get; set; } //your foreign table
    }
