        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransID,SuppliesID,OriginalDate,TransType,LastUpdatedBy,Contact,OpenClosed,CurrentStatus,CurrentStatusDate,RequsitionNumber,PONumber,DeliveryMonth,DeliveryYear,UnitsOrdered,Emergency,Comments,DeliveryUnitID")] ICS_Transactions iCS_Transactions)
        {
            if (ModelState.IsValid)
            {
                //lookup ICS_Supplies
                var supplyEntity = db.ICS_Supplies.Where(s => s.Supplies_ID == iCS_Transactions.SuppliesID).FirstOrDefault();
                if (supplyEntity != null)
                {
                    supplyEntity.OnHand = supplyEntity.OnHand - iCS_Transactions.UnitsOrdered;
                }
                db.Entry(iCS_Transactions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iCS_Transactions);
        }
