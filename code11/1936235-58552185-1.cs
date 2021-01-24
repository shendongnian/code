        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID)
        {
            var cheese = db.cheese.Find(id);
            if (cheese != null)
            {
                Cheese cheese = db.Cheese.Find(id);
                db.Cheese.Remove(cheese);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Cheese");
        }
