    @for (int i = 0; i < Model.ArticlesOnFirstSite.Count; i += 3)
    {
        <tr>
            @foreach (Article article in Model.ArticlesOnFirstSite.Skip(i).Take(3))
            {
                <td>@article.Title</td>
            }
        </tr>
    }
