        [HttpPost]
        public void Post([FromBody]string info)
        {
            Console.WriteLine(info);
        }
