/// <summary>
/// Get by Filter
/// </summary>
/// <param name="filter">user filters</param>
/// <returns></returns>
[Route("functionRoute")]
[HttpPost]
public IHttpActionResult GetUsersByFilter([FromBody] UserFilter filter)
{
            try
            {
                UserService service= new UserService ();
                List<User> list = service.GetByFilter(filter).Select(x => new User() {
                Id = x.Id,
                Name = x.Name,
                //every property except your image property
                }).ToList();
                List<UserCE> listCE = Mapper.Map<List<UserCE>>(list);
                return Ok(listCE);
            }
            catch (Exception ex)
            {
                TraceManager.LogError(ex);
                return InternalServerError(ex);
            }
}
