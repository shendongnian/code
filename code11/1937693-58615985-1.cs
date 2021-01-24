public static string GetName([CallerMemberName]string memberName = "") 
   => memberName; 
# Test
## Code 
class ReportResult { 
//(...)
public string Mama {get;set;} // Aka Source
}
public static string GetCaller([CallerMemberName]string memberName = "") => memberName; 
public async static Task Main()
{
    var offset = 1;
    var limit = 10;
        List<ReportResult> results = new List<ReportResult>() {
        await GetInvalid("ASC", offset, limit),
        await GetActive("ASC", offset, limit),
        await GetValid("ASC", offset, limit)
    };
    foreach(var r in results ) Console.WriteLine(r.Mama);
}
private static Task<ReportResult> GetValid(string v, object offset, object limit) {
    return Task.FromResult(new ReportResult{  Mama = GetCaller() });
}
private static Task<ReportResult> GetActive(string v, object offset, object limit) {
    return Task.FromResult(new ReportResult{ Mama = GetCaller() });
}
private static Task<ReportResult> GetInvalid(string v, object offset, object limit) {
    return Task.FromResult(new ReportResult{ Mama = GetCaller() });
}
## Output
GetInvalid
GetActive
GetValid
