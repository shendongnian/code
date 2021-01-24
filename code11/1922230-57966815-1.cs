csharp
public partial class Route
{
    ...
    
    public int? RouteOrgId { get; set; }    
    public virtual ICollection<RouteOrg> RouteOrg { get; set; }
    [NotMapped]
    public IEnumerable<Organization> Donors { 
        get {
            return this.RouteOrg.Select(ro => ro.Donor);
        }
    }
    [NotMapped]
    public IEnumerable<Organization> Agencies { get{
        return this.RouteOrg.Select( ro =>  ro.Agency);
    } }
}
When you want to get the Donors and Agencies of Routes, use `Include().ThenInclude()` to query as below:
csharp
var routes = await _context.Route
    .Include(r => r.RouteOrg)
        .ThenInclude(ro => ro.Agency)
    .Include(r => r.RouteOrg)
        .ThenInclude(ro => ro.Donor)
    ; 
