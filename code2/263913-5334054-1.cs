    public class PostFieldLengthSpecification : ISpecification<Post>
    {
        private  const string TITLE_LENGTH_RANGE = "5-100";
        private  const string BODY_LENGTH_RANGE = "20-10000";
        public bool IsSatisfiedBy(Post post)
        {
            return this.GetErrors(post).IsValid;
        }
        public ModelStateDictionary GetErrors(Post post)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();
            if (!post.Title.Trim().Length.Within(TITLE_LENGTH_RANGE))
                modelState.AddModelError(StongTypeHelpers.GetPropertyName((Post p) => p.Title),
                    "Please make sure the title is between {0} characters in length".With(TITLE_LENGTH_RANGE));
            if (!post.BodyMarkup.Trim().Length.Within(BODY_LENGTH_RANGE))
                modelState.AddModelError(StongTypeHelpers.GetPropertyName((Post p) => p.BodyMarkup),
                    "Please make sure the post is between {0} characters in length".With(BODY_LENGTH_RANGE));
            return modelState;
        }
    }
