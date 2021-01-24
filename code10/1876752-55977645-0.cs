using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
public class SampleController : Controller
{
    [HttpGet]
    [Route("")]
    public IActionResult ExampleGet([FromQuery] DataTableAjaxPostModel dataTableAjaxPostModel)
    {
        // You should be able to debug and see the value here
        var result = dataTableAjaxPostModel.search;
        return Ok();
    }
    public class DataTableAjaxPostModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public search search { get; set; }
        public List<Order> order { get; set; }
    }
    public class search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }
}
