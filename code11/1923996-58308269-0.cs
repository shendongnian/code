     Field<UserTypes>
            (
                "user",
                arguments: new QueryArguments
                (
                   new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "username" },
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "lastname" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return userManager.FindByIdAsync(id.ToString());
                }
          );
