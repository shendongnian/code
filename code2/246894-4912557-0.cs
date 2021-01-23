    public class ArticleValidator : AbstractValidator<Content>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.WMD).NotEmpty();
        }
    }
