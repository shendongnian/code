    [HttpPost]
    Public ActionResult Create([FromBody] CreateBinding binding)
    {
     var id = binding.ID;
     var name = binding.BoxName;
    ....
    }
