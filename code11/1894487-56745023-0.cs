        [HttpPost]
        public ActionResult SubmitButtonClick(string newArea, string newZone, string 
         newAC, string newCity, string newRegion)
        {
            System.Diagnostics.Debug.WriteLine("Area: " + newArea + ", Zone: " + newZone + ", newAC: " + newAC + ", newCity: " + newCity + ", newRegion: " + newRegion );
            areas.Add(new Areas
            {
                area = newArea,
                zone = Int32.Parse(newZone),
                areaCommunity = newAC,
                city = newCity,
                region = newRegion
            });
            System.Diagnostics.Debug.WriteLine("After add: " + areas[areas.Count- 
       1].area);
            return RedirectToAction("Index", area);
         }
