    foreach (SList subList in parentList)
    {
        if (subList.SubList.Count < 1)
            return string.Empty;
        for(int i = 0; i < subList.SubList.Count; i++)
        {
            if (string.Compare(subList.PName, lastPName) != 0)
            {
                subListItemsToHtml.AppendFormat(@"<div id='{0}-test' class='dropdown'>", subList.SubList[i].PName);
                subListItemsToHtml.Append("<ul>");
                subListItemsToHtml.AppendFormat(@"    <li><a href='{0}'>{1}</a></li>", subList.SubList[i].URL, subList.SubList[i].DisplayName);
                subListItemsToHtml.Append("</ul></div>");
            }
            else
            {
                subListItemsToHtml.AppendFormat(@"    <li><a href='{0}'>{1}</a></li>", subList.SubList[i].URL, subList.SubList[i].DisplayName);
            }
            lastPName = subList.SubList[i].PName;
        }
    }
