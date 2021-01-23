    sb.AppendLine("<li>");
    sb.AppendLine(
        helper.ActionLink(
            caption, 
            "CaptionCategory", 
            new { id = caption.Code }
        ).ToHtmlString()
    );
    sb.AppendLine("</li>");
