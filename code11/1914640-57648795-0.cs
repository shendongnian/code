    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get() {
            using (var context = new MaterializeQueryContext()) {
                return Ok(context
                    .MaterializeQuery
                    .Where(x=> x.Id > 1));
            }
        }
        public override OkObjectResult Ok(object model) {
            if (model is IQueryable queryable) {
                var toList = typeof(Enumerable)
                    .GetMethod(nameof(Enumerable.ToList))
                    .MakeGenericMethod(new[] { queryable.ElementType });
                var result = toList.Invoke(null, new[] { queryable });
                return base.Ok(result);
            }
            return base.Ok(model);
        }
    }
