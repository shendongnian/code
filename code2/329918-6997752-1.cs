    // new class in your project
    public class SelectListModel
    {
        public SelectList SL1 { get; set; }
        public SelectList SL2 { get; set; }
    }
    // updated version of your ActionResult    
    public ActionResult IndexStudents(Docent docent, int lessonid, int classid)
    {
        var myslm = new SelectListModel 
        {
            SL1 = new SelectList(docent.ReturnStudentsNormalAsString(lessonid, classid),
            SL2 = new SelectList(docent.ReturnStudentsNoClassAsString(lessonid, classid)
        };
        return View(myslm);
    }
    // updated view code
    <div class="editor-field">
    	<%: Html.DropDownList("IndexStudentsNormal", Model.SL1 as SelectList) %>  
    </div>
    <div class="editor-field">
    	<%: Html.DropDownList("IndexStudentsNoClass", Model.SL2 as SelectList) %>
    </div>
