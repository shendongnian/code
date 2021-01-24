        public class LinesParameter
        {
            public List<string> Lines { get; } = new List<string>();
        }
        public IActionResult Test([FromBody]LinesParameter lp)
