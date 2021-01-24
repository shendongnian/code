    public class MinistryViewModel
    {
       public int MinistryId { get; set; }
       public string Ministry { get; set; } 
       public string MemberGroup { get; set; }
    }
    
    var ministries = _context.Ministries
       .Select(x => new MinistryViewModel
       {
          MinistryId = x.MinistryId,
          Ministry = x.Name,
          MemberGroup = x.MemberGroup.Name
       }).ToList();
