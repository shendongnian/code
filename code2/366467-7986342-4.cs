    public class AddArticleBusinessValidationResultItem : BusinessValidationResultItem
    {
        public enum AddArticleValidationResultCode { UserDoesNotExist, UrlTitleAlreadyExists, LanguageDoesNotExist }
        public AddArticleBusinessValidationResultItem(ResultType resultType, string message, AddArticleValidationResultCode code)
            : base(resultType, message)
        {
            Code = code;
        }
        public AddArticleValidationResultCode Code { get; set; }
    }
