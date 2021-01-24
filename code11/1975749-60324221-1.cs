            String Properties = "Comma Separated List of Properties You actaully Need";
            List<User> AllUsers = new List<User>();
            IGraphServiceUsersCollectionPage users = graphServiceClient.Users
                                                        .Request()
                                                        .Select(Properties)
                                                        .GetAsync()
                                                        .Result;
            do
            {
                QueryIncomplete = false ;
                AllUsers.AddRange(users);
                if (users.NextPageRequest != null)
                {
                    users = users.NextPageRequest.GetAsync().Result;
                    QueryIncomplete = true;
                }
            }while (QueryIncomplete);
            return AllUsers;
