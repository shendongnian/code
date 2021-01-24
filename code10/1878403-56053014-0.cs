    // POST: About/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NameApp,ContactInformation,Email,Fax,Phone,ReleaseDay,LogoPathOfProduction,IsShow,LatestVersion,ReleaseNotes")] AboutInformation about,List<string> imagesToDelete, List<HttpPostedFileBase> images, bool? isShowInfo)
        {
            if (ModelState.IsValid)
            {
                //update....
            }
            TempData["ToastMessage"] = "Sucessfully";
            var message = TempData["ToastMessage"];
            TempData.Keep("ToastMessage");
            return RedirectToAction("Edit");
        }
