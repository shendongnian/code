    [HttpPost]
    public JsonResult Delete([FromBody]string id) {
        _bookService.Remove(id);
        return new JsonResult("Deleted");
    }
