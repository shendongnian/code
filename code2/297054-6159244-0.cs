    <form method="post">
        ...
        <select name="List">
            <option value="1">Test1</option>
            <option value="2">Test2</option>
        </select>
        <select name="List">
            <option value="3">Test3</option>
            <option value="4">Test4</option>
        </select>
        ...
    </form>
    public ActionResult OrderProcessor()
    {
        string[] ids = Request.Form.GetValues("List");
    }
