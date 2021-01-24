    void Login(string username, string password){
      var user = //query db for user. Get: password, attempts = number of failed password attempts, lockedoutuntilutc = a date of when the user is locked out until; no login will ever work before this date
      //if the user is currently locked out, bomb out, don't increase the failed attempts etc
      if(DateTime.UtcNow < user.LockedOutUntilUtc)
        throw new Exception("You're locked out. Try again in {(user.LockedOutUntilUtc - DateTime.UtcNow).TotalSeconds)} seconds");
      //ok the user may make an attempt - is it correct?
      if(user.Password == password.GetHashCode()){ //or better hashing algo
        //correct; reset the attempt, record their successful login; leave the lockout date alone (it's in the past - who cares about it?
        user.Attempts = 0;
        user.LastLoginUtc = DateTime.UtcNow;
      } else { //login failed
        user.Attempts++; //increment fails
        user.LockedOutUntilUtc = DateTime.UtcNow.AddSeconds(Math.Pow(2, user.Attempts + 1)); //lock them out for exponentially longer times the more fails they make
      }
      //save db
    }
