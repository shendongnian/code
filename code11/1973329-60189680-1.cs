        [HttpGet("{json}")]
        public async Task<IActionResult> GetAsync([FromRoute] string json)
        {
            var dictionary = JsonConvert.DeserializeObject<IDictionary<string, string>>(json);
            return await Task.FromResult(Ok());
        }
