    public static async Task<TResult[]> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }
        return await Task.WhenAll(source.Select(selector));
    }
    var temp = await _validators
        .SelectAsync(v => v.ValidateAsync(request));
    var result = temp.SelectMany(result => result.Errors)
        .Where(f => f != null)
        .ToList();
