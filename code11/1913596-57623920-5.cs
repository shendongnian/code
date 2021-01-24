    public class UserForUpdateDto
    {
        public int UserId { get; set; }
        public string Status { get; set; }
        public  List<Referal> Referals { get; set; }
        public List<GroupViewModel> Groups { get; set; }
    }
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
