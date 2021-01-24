    [Route("v1/groups")]
    public class GroupsController : Controller {
        //...omitted for brevity
        //GET v1/groups
        [HttpGet("")]
        public IActionResult Get() {
            IEnumerable<Group> groups = service.GetGroups()
                .Select(group => {            
                    var url = Url.RouteUrl("GetGroup", new { name = group.Name });
                    group.Url = url;
                    return group;
                }).ToList();
            return Ok(groups);
        }
    
        //GET v1/groups/1234
        [HttpGet("{name}", Name = "GetGroup")]
        public IActionResult Get(string name) {
            var group = service.GetGroup(name);
            if(group == null) return NotFound();
            return Ok(group);
        }
    }
