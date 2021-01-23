    var prefs = Membership
                    .GetAllUsers()
                    .OfType<MembershipUser>()
                    .Select(u => WebProfile.GetProfile(u.UserName).Preferences)
                    .Where(p => SendAlertToSMS.Equals(true) && SMSAlertTypeIds.Contains(alertTypeId));
    var carriers = new AlertRepository().FindAllMobileCarriers().ToList();
    foreach (UserPreferences p in prefs) 
    {
        var carrier = carriers.FindOrDefault(c => c.Id.Equals(p.MobileCarrierId));
        yield return PopulateAddress(c, p);
    }
