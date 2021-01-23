    public class Initializer : DropCreateDatabaseAlways<MeetPplDB>
    {
        protected override void Seed(MeetPplDB context)
        {
            var Members = new List<Member>
            {
                new Member {
                    Email = "dave@dave.com",
                    City = "San Francisco",
    .....
