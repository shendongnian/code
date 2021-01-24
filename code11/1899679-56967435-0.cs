    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Date,PolicyNumber,OwnerName,SendTo,EmailAddress,ModifiedDate,LastModifiedBy,DeliveryMethod, Default, Standard, Emailed")] ReprintEditViewModel xrCertReprint)
    {
        if (ModelState.IsValid)
        {
                //string dm = string.Join(", ", DeliveryMethod);
                string dm = "";
                if (xrCertReprint.IsDefault == true)
                    dm = "Default";
                if (xrCertReprint.IsStandard == true)
                    if (dm.Length > 1)
                        dm = dm + ", " + "Standard";
                    else
                        dm = "Standard";
                if (xrCertReprint.IsEmailed == true)
                    if (dm.Length > 1)
                        dm = dm + ", " + "Emailed";
                    else
                        dm = "Emailed";
            return RedirectToAction(nameof(Index));
        }
        return View(xrCertReprint);
    }
