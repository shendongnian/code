[HttpPost]
public ActionResult _AddEditLicense(LicenseInfo data)
{
   if (ModelState.IsValid())
   {
      // Execute code
   }
   // Not validated, return to the view
   return View(data);
}
