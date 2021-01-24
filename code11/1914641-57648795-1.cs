    public class HomeController : Controller {
        public IActionResult Index() {
            using (var context = new MaterializeQueryContext()) {
                return View(context
                    .MaterializeQuery
                    .Where(x => x.Id > 1));
            }
        }
        public override ViewResult View(object model) {
            if (model is IQueryable queryable) {
                var toList = typeof(Enumerable)
                    .GetMethod(nameof(Enumerable.ToList))
                    .MakeGenericMethod(new[] { queryable.ElementType });
                var result = toList.Invoke(null, new[] { queryable });
                return base.View(result);
            }
            return base.View(model);
        }
    }
