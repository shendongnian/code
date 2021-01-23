    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    namespace sbs.Lib.Web.ValidationAttributes
    {
        public static class IClientValidatableExtensions
        {
            /// <summary> Returns the HTML ID of the specified view model property. </summary>
            /// <remarks> Based on: http://stackoverflow.com/a/21018963/1637105 </remarks>
            /// <param name="metadata"> The model metadata. </param>
            /// <param name="viewContext"> The view context. </param>
            /// <param name="propertyName"> The name of the view model property whose HTML ID is to be returned. </param>
            public static string GetHtmlId(this IClientValidatable me,
                                           ModelMetadata metadata, ControllerContext context,
                                           string propertyName)
            {
                var viewContext = context as ViewContext;
    
                if (viewContext == null || viewContext.ViewData.TemplateInfo.HtmlFieldPrefix == string.Empty) {
                    return propertyName;
                } else {
                    // This is tricky.  The "Field ID" returned by GetFullHtmlFieldId is the HTML ID
                    // attribute created by the MVC view engine for the property whose validator is
                    // being set up by the caller of this routine. This code removes the property
                    // name from the Field ID, then inserts the specified property name.
                    // Of course, this only works for elements on the same page as the caller of
                    // this routine!
                    string fieldId = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId("");
                    fieldId = fieldId.Remove(fieldId.LastIndexOf("_"));
                    return fieldId + "_" + propertyName;
                }
            }
        }
    }
