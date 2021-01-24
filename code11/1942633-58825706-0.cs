static class Program {
    public static List<User> Users = new List<User>();
    public static List<Claim> Claims = new List<Claim>();
    public static List<Valuation> Valuations = new List<Valuation>();
    public static List<Status> Statuses = new List<Status>();
    public static List<StatusHistory> StatusHistories = new List<StatusHistory>();
    static void Main()
    {
        DataSeed();
        var claims = GetClaims(true,0,DateTime.MinValue,DateTime.MaxValue);
        Console.Write(claims);
    }
    static List<ClaimDto> GetClaims(bool active,int userId, DateTime fromDate, DateTime toDate){
        var claimsInDb = (from status in Program.Statuses
                                join statusHistory in context.StatusHistories on status.StatusId equals statusHistory.StatusId
                                join valuation in context.Valuations on statusHistory.StatusHistoryId equals valuation.StatusHistoryId
                                join claim in context.Claims on statusHistory.ClaimId equals claim.ClaimId
                                join user in context.Users on claim.AssignedTo equals user.UserId into joined
                                from joinedUser in joined.DefaultIfEmpty()
                                      where status.Active & active
                                          ? status.Name != "Complete"
                                          : status.Name == "Complete"
                                            & statusHistory.CreatedDt > fromDate & statusHistory.CreatedDt < toDate
                                            & userId == 0
                                              ? joinedUser.Id != -1
                                              : joinedUser.Id == userId
                                      group new ClaimDto
                                    {
                                        Id = claim.Id,
                                        AssignedToUserFullName = joinedUser.FullName,
                                        CreatedDt = claim.CreatedDt,
                                        Status = status.Name,
                                        Version = valuation.Version
                                    } 
                                    by new
                                    {
                                        claim.Id
                                    }
                                into grouped
                                
                                select grouped.FirstOrDefault()
                            ).ToList();
        return claimsInDb;
    }
    static void DataSeed(){
    //dataSeed
        Users.Add(new User
        {
            Id = 1,
            FullName = "Dmitry Post",
        });
        Claims.AddRange(new List<Claim>
        {
            new Claim
            {
                Id = 1,
                AssignedTo = 1,
                CreatedDt = DateTime.Now,
                ActiveEvaluationId = 1
            },
            new Claim
            {
                Id = 2,
                AssignedTo = 1,
                CreatedDt = DateTime.Now,
                ActiveEvaluationId = 2
            }
        });
        Valuations.AddRange(new List<Valuation>
        {
            new Valuation
            {
                Id = 1,
                Version = 1,
                ClaimId = 1,
                StatusHistoryId = 2,
            },
            new Valuation
            {
                Id = 2,
                Version = 1,
                ClaimId = 2,
                StatusHistoryId = 5,
            }
        });
        Statuses.AddRange(new List<Status>
        {
            new Status
            {
                Id = 1,
                Name = "New",
                Active = true,              
            },
            new Status
            {
                Id = 2,
                Name = "In Progress",
                Active = true,
            },
            new Status
            {
                Id = 3,
                Name = "Complete",
                Active = true,
            }
        });
        StatusHistories.AddRange(new List<StatusHistory>
        {
            new StatusHistory
            {
                Id = 1,
                ClaimId = 1,
                CreatedDt = DateTime.Now.AddDays(-10),
                StatusId = 1
            },
            new StatusHistory
            {
                Id = 2,
                ClaimId = 1,
                CreatedDt = DateTime.Now.AddDays(-1),
                StatusId = 2
            },
            new StatusHistory
            {
                Id = 3,
                ClaimId = 2,
                CreatedDt = DateTime.Now.AddDays(-10),
                StatusId = 1
            },
            new StatusHistory
            {
                Id = 4,
                ClaimId = 2,
                CreatedDt = DateTime.Now.AddDays(-9),
                StatusId = 2
            },
            new StatusHistory
            {
                Id = 5,
                ClaimId = 2,
                CreatedDt = DateTime.Now.AddDays(-8),
                StatusId = 3
            },
        });
    }
}
//objects
class ClaimDto{
public int Id {get;set;}
public DateTime CreatedDt {get;set;}
public string Status {get;set;}
public int Version {get;set;}
public string AssignedToUserFullName {get;set;}
}
class Status{
public int Id {get;set;}
public string Name {get;set;}
public bool Active {get;set;}
}
class StatusHistory{
public int Id {get;set;}
public int StatusId {get;set;}
public int ClaimId {get;set;}
public DateTime CreatedDt {get;set;}
}
class Claim{
public int Id {get;set;}
public int ActiveEvaluationId {get;set;}
public DateTime CreatedDt {get;set;}
public int AssignedTo {get;set;}
}
class Valuation{
public int Id {get;set;}
public int Version {get;set;}
public int ClaimId {get;set;}
public int StatusHistoryId {get;set;}
}
class User{
public int Id {get;set;}
public string FullName {get;set;}
}
