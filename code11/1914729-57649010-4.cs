public async Task<byte[]> ArticlesCSVExport<T>(
        Request searchObject, Func<T, object[]> extractValuesFunction)
{
    var lineElements = result.Select(extractValuesFunction).ToList();
    var csv = new StringBuilder();
    lineElements.ForEach(line =>
    {
        csv.AppendLine(string.Join(",", line));
    });
    byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", columnHeaders)}\r\n{csv.ToString()}");
    return buffer;
}
    
(This also assumes that `result` is a collection of `T` instead of a collection of `Article`, but that's unclear because `result` isn't declared in this method.)
Now, instead of having inline code saying how to take an `Article` and return an `object[]`, you'll just execute that function for each item.
Calling the function could look like this:
    var output = await ArticlesCSVExport<Article>(
        searchObject,
        article =>
            new object[]
            {
                $"\"{article.ArticleName}\"",
                $"\"{article.Price}\"",
                $"\"{article.ArticleType}\"",
                $"{(article.Active == true ? "Active" : "Inactive")}"
            });
In that example we're passing in an anonymous function, but we can pass any function that has the correct signature.
Suppose we have a class like this with a static method:
    public static class CsvFormatFunctions
    {
        public static object[] GetArticleValues(Article article)
        {
            return new object[]
            {
                $"\"{article.ArticleName}\"",
                $"\"{article.Price}\"",
                $"\"{article.ArticleType}\"",
                $"{(article.Active == true ? "Active" : "Inactive")}"
            });
        }
    }
...then we could pass that method as a parameter:
    var output = await ArticlesCSVExport<Article>(
        searchObject, CsvFormatFunctions.GetArticleValues);
Depending on details that I can't see, the class might need to be generic instead of the method. If that's the case then you would just remove the generic argument `<T>` from the method and put it on the class declaration instead.
