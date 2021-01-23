        [HttpPost]
        public ActionResult Edit(Truck_Mng truck_mng)
        {
            if (!ModelState.IsValid)
            {
                //Possible show an error message
            }
            using (var context = new MyDataContext())
            {
                context.SomeTable.AddObject(new SomeTable
                                                {
                                                    TruckName = truck_mng.Name,
                                                    TruckDest = truck_mng.Dest
                                                });
                context.SaveChanges();
            }
            return RedirectToAction("index");
        }
