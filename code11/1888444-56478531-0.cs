        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult
            {
                Data = new
                {
                    userId = 321,
                    account = new
                    {
                        fname = "Adam",
                        lname = "Silver",
                        features = new object[]{
                        new
                    {
                        available = true,
                        status = "open",
                        admin = false
                    }
                    }
                    }
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
