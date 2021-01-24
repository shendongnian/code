     public class TestController : CustomBaseController
        {
            public IActionResult Test()
            {
                return Ok($"Test {DateTime.UtcNow}");
            }
        }
