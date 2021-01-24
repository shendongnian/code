        [HttpPost, ActionName("Complete")]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteConfirmed(int id)
        {
            UserCurrWorkout userCurrWorkout = db.UserCurrWorkouts.Find(id);
            var oldWorkouts = new UserWorkoutHistory { UserId = userCurrWorkout.UserId, UserOldWorkout = userCurrWorkout.UserActiveWorkout };
            db.UserWorkoutHistories.Add(oldWorkouts);
            db.UserCurrWorkouts.Remove(userCurrWorkout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
