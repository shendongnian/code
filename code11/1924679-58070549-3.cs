     public ActionResult _AddItem(string itemIndex, string itemLabel)
            {
                ViewData["itemIndex"] = itemIndex;
                ViewData["itemLabel"] = itemLabel;
                return PartialView(new CategoryModel { Id = 5, Text = "Sample 5" });
            }
