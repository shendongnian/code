    [Route("v1/groups")]
    public class GroupsController : Controller {
        //...omitted for brevity
        //GET v1/groups
        [HttpGet("")]
        public IActionResult Get() {
            IEnumerable<Group> groups = service.GetGroups();
            foreach(var group in groups) {
                var url = Url.RouteUrl("GetGroup", new { name = group.Name });
                group.Url = url;
            }
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
