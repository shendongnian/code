    public class ArticleValidator : AbstractValidator<ArticleViewModel>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();        
        }
    }
