    @inherits System.Web.Mvc.WebViewPage
    @{
        ViewBag.Title = "Entity Index";
        List<MyEntity> MyEntities = new List<MyEntity>();
        MyEntities.Add(new MyEntity());
        MyEntities.Add(new MyEntity());
        MyEntities.Add(new MyEntity());
    }
    <div>
        @{
            foreach(var M in MyEntities)
            {
                //squiggly lines below. Hovering says: cannot convert method group 'partial' to non-delegate type Object, did you intend to envoke the Method?
                @Html.Partial("MyOtherView.cshtml");
            }
        }
    </div>
