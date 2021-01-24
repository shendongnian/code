                //first create List<selectlistitem>
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                selectListItems.Add(new SelectListItem() { Value = "", Text = "Select" });
    
                foreach (var item in db.Categories.ToList())
                {
                    selectListItems.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
                }
                ViewBag.categ=selectListItems;
               //use it in view
               @Html.DropDownList("categ",(List<SelectListItem>)ViewBag.categ, "-- Select Category -- ", new { id = "subCategory" })
