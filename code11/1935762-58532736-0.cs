var blogs = context.Blogs
    .FromSqlRaw("EXECUTE dbo.GetMostPopularBlogs")
    .ToList();
> FromSqlRaw allows you to use named parameters in the SQL query string, which is useful when a stored procedure has optional parameters:
>     var user = new SqlParameter("user", "johndoe");
> 
>     var blogs = context.Blogs
>         .FromSqlRaw("EXECUTE dbo.GetMostPopularBlogsForUser @filterByUser=@user", user)
>         .ToList();
