c#
public ActionResult Orders(int? page)
   {
       var model = db.Orders.ToList();
       int pageSize = 3;
       int pageNumber = (page ?? 1);
       return View(model.ToPagedList(pageNumber, pageSize));
   }
View:
c#
@using PagedList;
@using PagedList.Mvc
@model IPagedList<Store.Models.Orders>
@Html.PagedListPager(Model, page => Url.Action("Index", new { page }), new PagedListRenderOptions() { Display = PagedListDisplayMode.IfNeeded })
