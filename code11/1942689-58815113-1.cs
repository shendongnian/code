public class RaidRequest
{
    public int Id { get; set; }
    public string Access { get; set; }
    public string UserOrAdmin { get; set; }
    public string Department { get; set; }
    public string NameSurname { get; set; }
    public string Reason { get; set; }
    public string UNCPath { get; set; }
}
public async Task<IActionResult> Index(string searchString)
    {
        var requests = from m in _context.RaidRequest select m;
        if (!String.IsNullOrEmpty(searchString))
        {
            requests = requests.Where(s => s.Reason.Contains(searchString) || s.UNCPath.Contains(searchString) || s.Department.Contains(searchString)|| s.Access.Contains(searchString)|| s.NameSurname.Contains(searchString)|| s.UserOrAdmin.Contains(searchString));
        }
        return View(await requests.ToListAsync());
    }
