    public ActionResult AjaxBindingChildCategories(int parentCategoryId)
    {
       IEnumerable<Category> childCategoryList = categoryService.GetChildCategoriesByParentCategoryId(parentCategoryId);
       var childList =
          from c in childCategoryList
          select new
          {
             Id = c.Id,
             Name = c.Name
          };
    
          return Json(childList, JsonRequestBehavior.AllowGet);
    }
