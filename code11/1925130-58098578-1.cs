        public class UserIdParams : CommonParams
        {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]     
        public string DelimitedUserIds { get; set; }
        }
