    namespace Your.Models
    {
        public class DisplayModel
        {
            public string Month {get;set;}
            public string Extra {get;set;}
        }
    }
    
    [HttpPost]
        public ActionResult Display(DisplayModel model)
        {
            if (ModelState.IsValid)
            {
                string month = model.Month;
                string extra = model.Extra;
    
                return RedirectToAction("Index");
            }
            return View();
        }
    
    @using Your.Models
    @model DisplayModel
    
    @using (Html.BeginForm("Display", "Home", new { id="displayview" }))
    {
        @Html.AntiForgeryToken()
        <div>
                Month:<input type="text" name="Month" id="MonthInput">
                Extra:<input type="text" name="Extra" id="ExtraInput"><br /><br />
                <input type="submit" value="Add" class="btn btn-default">
        </div>
    }
