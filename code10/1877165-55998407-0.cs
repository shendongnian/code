       [HttpPut]
        public IActionResult Test([FromBody] List<RootObject> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.name);
            }
            return Json("ok");
        }
