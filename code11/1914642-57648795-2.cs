    public IActionResult Get() {
        using (var context = new MaterializeQueryContext()) {
            return new OkObjectResult(context
                .MaterializeQuery
                .Where(x=> x.Id > 1));
        }
    }
