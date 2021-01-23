    public static class HtmlExtensions
    {
         public static MvcHtmlString SecurityQuestionDropDown(this HtmlHelper helper)
         {
              return helper.DropDownList(....,new SelectList(membershipRepository.GetSecurityQuestionList(), "Question", "Question"));
         }
    }
