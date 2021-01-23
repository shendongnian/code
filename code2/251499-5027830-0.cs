    // from account controller - put the enum, etc in there for brevity
    public enum Stage
    {
        [Description("")]
        BLANK = -99,
        [Description("No Data")]
        NoData = 9999,
        [Description("Nil")]
        Nil = 0,
        [Description("Action")]
        SAction = 1,
        [Description("Action Plus")]
        SActionPlus = 2,
        [Description("Full")]
        Full = 3
    }
    public static IEnumerable<SelectListItem> GenerateSenStageList()
    {
        var values = from Stage e in Enum.GetValues(typeof(Stage))
                     select new { ID = (int)e, Name = e.ToDescription() };
        var sellist= new SelectList(values, "Id", "Name", (int)Stage.BLANK);
        return sellist;
    }
    public virtual ActionResult LogOn()
    {
        var res = GenerateSenStageList();
        ViewData["StageList"] = res;
        return View();
    }
    // the ToDescription() extension method
    public static class Extn
    {
        public static string ToDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);
            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
    // then in the LogOn view:
    <%= Html.DropDownList("Stage", (IEnumerable<SelectListItem>)ViewData["StageList"])%>
