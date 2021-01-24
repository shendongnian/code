 c"
using (var con = _connFactory())
{
    data = con.Query<byte[]>("SELECT Image FROM RecipeImage WHERE RecipeId = @recipeId", new { recipeId }).FirstOrDefault();
}
Personally I would prefer:
 c#
using (var con = _connFactory())
{
    data = con.QuerySingle<byte[]>("SELECT Image FROM RecipeImage WHERE RecipeId = @recipeId", new { recipeId });
}
which will throw an exception if more or less than one image is found.
