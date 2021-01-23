            public static MvcHtmlString Concat(params MvcHtmlString[] value)
            {
                StringBuilder sb = new StringBuilder();
                foreach (MvcHtmlString v in value) if (v != null) sb.Append(v.ToString());
                return MvcHtmlString.Create(sb.ToString());
            }
