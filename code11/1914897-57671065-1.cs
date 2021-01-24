    public JsonResult GetValuesForDropdownlist2(int id)
    {
        var selected = db.dropdownlist1_Table.Where(t => t.Id == id).FirstOrDefault();
    
        return Json(new SelectList(db.dropdownlist2_Table.Where(t => (t.Column_To_Filter == selected.Id)), "Column_ID", "Column_Description"));
    }
