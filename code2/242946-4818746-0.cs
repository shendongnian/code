    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    public static class DropDownListForHelper
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> dropdownItems, bool disabled)
        {
            object htmlAttributes = null;
            if(disabled)
            {
                htmlAttributes = new {@disabled = "true"};
            }
            return htmlHelper.DropDownListFor<TModel, TProperty>(expression, dropdownItems, htmlAttributes);
        }
    }
