`cs
public class Article {
 public int id { get; set; }
 public string Title { get; set; }
 public string Introduction { get; set; }
 public string AuthorId { get; set; }
 public AppUser Author { get; set; }
 public DateTime PublishDate { get; set; }
}
public class ArticleSummary {
 public int Id { get; set; }
 public string Title { get; set; }
 public string Introduction { get; set; }
}
`
and here is the mapping :
`cs
Expression<Func<Article, ArticleSummary>> mapArticle = x => new ArticleSummary {
    Id = x.Id,
    Title = x.Title,
    Introduction = x.Introduction
};
`
and here is the "simplified" data function :
`cs
// T is Article model
// U is ArticleSummary model
public async Task<ICollection<U>> SelectListAsync<T, U>(
            Expression<Func<T, bool>> search,
            Expression<Func<T, U>> select) where T : class
{
    var query =
    _context.Set<T>()
    .Where(search)
    .Select(select);
    return await query.ToListAsync();
}
`
you can call it by passing mapping expression to select property.
