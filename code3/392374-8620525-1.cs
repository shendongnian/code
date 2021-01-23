    [Route("js/lang.js")]
    public ActionResult Lang()
    {
        ...
        return new JsonpResult(result, "cb");
    }
