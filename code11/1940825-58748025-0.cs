C#
var userDetails = await dbConnection.QueryAsync<
User,Business,UserAndBusiness>(@"
                        select User_Id UserId,User_Name UserName,Business_Id BusinessId,
                        Business_Name BusinessName from Users u join Business b on u.User_Id=b.User_Id",
                        map:(u,b)=>
                        {
                            UserAndBusiness ub = new UserAndBusiness();
                            ub.UserDetails=u;
                            ub.BusinessDetails=b;
                            return ub;
                        },
                        splitOn:"BusinessId"
                        );
 
