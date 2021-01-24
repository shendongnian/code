    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "TravelID,RequestedBy,DateRequested,TravelDescription,DestinationCity,DestinationState,StartDate,EndDate,EstRegistrationPerPerson,EstAirfarePerPerson,EstGroundPerPerson,EstLodgingPerPerson,EstMealsPerPerson,DepartureCity,DepartureState,DepartureDate,DepartureTimeRange,ReturnFromCity,ReturnFromState,ReturnFromDate,ReturnFromTimeRange,FlightNote,Hotel,HotelPhone,HotelNote,NeedHotelArrangements,NeedFlightArrangements,NeedRentalCarArrangements,IsTripInTravelBudget,Justification,OtherNote,SupAuth,SupAuthDate,CEOAuth,CEOAuthDate,ActRegistrationPerPerson,ActAirfarePerPerson,ActGroundPerPerson,ActLodgingPerPerson,ActMealsPerPerson")] Travel travel, HttpPostedFileBase upload)
    {
        if (ModelState.IsValid)
        {
            db.Entry(travel).State = EntityState.Modified;
            db.SaveChanges();
            if (upload != null && upload.ContentLength > 0)
            {
                var file = new Files
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    FileType = upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    file.Content = reader.ReadBytes(upload.ContentLength);
                }
                travel.Files = new List<Files> { file };
            }
            db.SaveChanges();
            return RedirectToAction("Details", "Travel", new { id = travel.TravelID });
        }
        return View(travel);
    }
