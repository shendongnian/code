    public ActionResult GetTreeview(string id, string company)
    {
        // company is not being used...
        var parentId = Convert.ToInt32(id);
        var jsTree =
            (from category in db.Categories
             where category.ICG_PARENT_ID == parentId
             orderby category.ICG_CATEGORY_NAME
             select new JsTreeModel
             {
                 data = category.ICG_CATEGORY_NAME,
                 attr = new JsTreeAttribute { id = category.ICG_CATEGORY_ID.ToString() },
                 state = "closed",
             }).ToArray();
        return Json(jsTree, JsonRequestBehavior.AllowGet);
    }
