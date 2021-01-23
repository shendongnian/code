    public class Initializer : DropCreateDatabaseAlways<MeetPplDB>
    {
        protected override void Seed(MeetPplDB context)
        {
            var _members = new List<Member>
            {
                new Member {
                    Email = "dave@dave.com",
                    City = "San Francisco",
    
    ....
    
    
    _members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
