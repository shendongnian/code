            // MvcTools.ExtensionMethods.MvcHtmlStringExtensions.Concat
            public static MvcHtmlString Concat(params MvcHtmlString[] strings)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
    
                foreach (MvcHtmlString thisMvcHtmlString in strings)
                {
                    if (thisMvcHtmlString != null)
                        sb.Append(thisMvcHtmlString.ToString());
                } // Next thisMvcHtmlString
    
                MvcHtmlString res = MvcHtmlString.Create(sb.ToString());
                sb.Clear();
                sb = null;
    
                return res;
            } // End Function Concat
