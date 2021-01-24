        [EnableQuery]
        [HttpGet("[action]")]
        public IQueryable<YourType> All()
        {
            var assets = _service.GetAllAssets(); //Where assets is IQueryable
            return Ok(assets);
        }
