        @Html.Action("Menu", "MyController", new { data = Model.Foo.Bar})
        [ChildActionOnly]
        public ActionResult Menu(Bar data )
        {
            return PartialView("Menu", data );
        }
