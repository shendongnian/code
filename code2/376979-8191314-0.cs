     public static class StatusExtensions
        {
            public static IHtmlString StatusBox<TModel>(
                this HtmlHelper<TModel> helper,
                Expression<Func<TModel, RowInfo>> ex
            )
            {
                var createdEx =
                    Expression.Lambda<Func<TModel, DateTime?>>(
                        Expression.Property(ex.Body, "Created"),
                        ex.Parameters
                    );
                var modifiedEx =
                    Expression.Lambda<Func<TModel, DateTime?>>(
                        Expression.Property(ex.Body, "Modified"),
                        ex.Parameters
                    );
                var a = "a" + helper.HiddenFor(createdEx) +
                    helper.HiddenFor(modifiedEx);
                return new HtmlString(
                    "Some things here ..." +
                    helper.HiddenFor(createdEx) +
                    helper.HiddenFor(modifiedEx)
                );
            }
        }
