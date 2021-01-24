        [HttpGet]
        [Route("v1/ElectricityAll")]
        public IActionResult ElBlockedGetV1()
        {
            return new JsonResult(_context.ElBlockeds.ToList());
        }
        [HttpGet]
        [Route("v2/ElectricityAll")]
        public IActionResult ElBlockedGetV2()
        {
            return new JsonResult(_context.ElBlockeds.Where(x=>x.Status == Status.Active).ToList());
        }
