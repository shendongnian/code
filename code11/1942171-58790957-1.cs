      public void Update(UserViewModel userVM)
      {
          var user = db.Users.Find(userVM.Id);
          if(user != null)
          {
            user.Name = userVM.Name;
            user.Surname = userVM.Surname;
            
            var address = user.Address;
            address.City = userVM.City;
            address.Address = userVM.Address;
        
            db.SaveChanges();
          }
        }
