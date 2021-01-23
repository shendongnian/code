        {
            string tooltip = string.Empty;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(resourceKey))
            {
                var resources = GetAllResourceValues();
                if (resources.ContainsKey(resourceKey))
                {
                    tooltip = resources[resourceKey].Value;
                }
            }
            sb.Append("<label");
            if (!string.IsNullOrEmpty(labelFor))
            {
                sb.AppendFormat(" for=\"{0}\"", labelFor);
            }
            if (!string.IsNullOrEmpty(labelId))
            {
                sb.AppendFormat(" Id=\"{0}\"", labelId);
            }
            if (!string.IsNullOrEmpty(className))
            {
                sb.AppendFormat(" class=\"{0}\"", className);
            }
            if (!string.IsNullOrEmpty(tooltip))
            {
                sb.AppendFormat(" data-toggle='tooltip' data-placement='auto left' title=\"{0}\"",tooltip);
            }
            if (isRequired)
            {
                sb.AppendFormat("><em class='required'>*</em> {0} </label></br>", text);
            }
            else
            {
                sb.AppendFormat(">{0}</label></br>", text);
            }
            return MvcHtmlString.Create(sb.ToString());
        }`
