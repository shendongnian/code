    private static IEnumerable<SelectListItem> GenerateSenStageList()
    {
        var values = from Stage e in Enum.GetValues(typeof(Stage))
            select new { ID = (int)e, Name = e.ToDescription() };
        return new SelectList(values, "Id", "Name", values.Cast<dynamic>().Where(x => (x.ID == (int)Stage.BLANK)));
    }
 
