        [HttpPost]
        public ActionResult Edit(Truck_Mng truck_mng)
        {
            if (!ModelState.IsValid)
            {
                //Possible show an error message
            }
            using (var context = new MyDataContext())
            {
                context.Truck_Mng.AddObject(truck_mng);
                context.SaveChanges();
            }
            return RedirectToAction("index");
        }
