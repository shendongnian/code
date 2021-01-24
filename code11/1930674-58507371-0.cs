            PaginatedResult<User> usersX = smartsheet.UserResources.ListUsers(null, 
                new List<ListUserInclusion> { ListUserInclusion.LAST_LOGIN },
                new PaginationParameters(true, null, null));
            foreach (User tmpUser in usersX.Data)
            {
                Console.WriteLine(tmpUser.LastLogin); 
            }
