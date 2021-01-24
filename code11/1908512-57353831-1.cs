    public static void Main()
    {
        var table = new List<TBL_USER>
        {
            new TBL_USER(1, 1, 1),
            new TBL_USER(2, 1, 2),
            new TBL_USER(3, 2, 1),
            new TBL_USER(5, 4, 1),
            new TBL_USER(6, 4, 2),
            new TBL_USER(7, 5, 1),
            new TBL_USER(8, 5, 2),
            new TBL_USER(9, 5, 3)
        };
        var userWithOnlyRole2 = table
            .GroupBy(tbl => tbl.UserId) // Group the lines with the same UserId
            .Where(grp => grp.Count() == 1 && grp.FirstOrDefault()?.RoleId == 2) // Get the list of group that have only one line (one role) and the RoleId is 2
            .FirstOrDefault()? // Get the First group
            .FirstOrDefault()?.UserId; // Get the First line of this group and then the UserId
    }
    public class TBL_USER
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public TBL_USER(int id, int user, int role)
        {
            Id = id;
            UserId = user;
            RoleId = role;
        }
    }
