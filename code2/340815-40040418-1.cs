    public static class SortHelper
    {
        public static Expression<Func<UserApp, object>> UserApp(string orderProperty)
        {
            orderProperty = orderProperty?.ToLowerInvariant();
            switch (orderProperty)
            {
                case "firstname":
                    return x => x.PersonalInfo.FirstName;
                case "lastname":
                    return x => x.PersonalInfo.LastName;
                case "fullname":
                    return x => x.PersonalInfo.FirstName + x.PersonalInfo.LastName;
                case "email":
                    return x => x.Email;
            }
        }
    }
