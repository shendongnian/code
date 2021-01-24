    foreach (var user in users)
    {
        user.Photos.SingleOrDefault().IsApproved = true;
        user.LocationPoint = new Point(user.Location.Longitude, user.Location.Latitude) {SRID = user.Location.SRID};
        _userManager.CreateAsync(user, "password").Wait();
        _userManager.AddToRoleAsync(user, "Member").Wait();
    }
