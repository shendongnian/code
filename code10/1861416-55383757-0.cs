            if (ModelState.IsValid)
            {
                db.ClinicalAssets.Add(clinicalAsset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "AssetTypeID", "AssetTypeName", clinicalAsset.AssetTypeID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", clinicalAsset.ProductID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "ModelName", clinicalAsset.ModelID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", clinicalAsset.ManufacturerID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", clinicalAsset.SupplierID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", clinicalAsset.TeamID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "StaffName", clinicalAsset.StaffID);
            ViewBag.InspectionOutcomeID = new SelectList(db.InspectionOutcomes, "InspectionOutcomeID", "InspectionOutcomeResult", clinicalAsset.InspectionOutcomeID);
            var Budgets = (from m in db.BudgetCodes
                           select new SelectListItem
                           {
                               Text = m.Code + " | " + m.BudgetCodeName,
                               Value = m.BudgetCodeID.ToString()
                           });
            ViewBag.BudgetsList = new SelectList(Budgets, "Value", "Text");
            return View(clinicalAsset);
        }
