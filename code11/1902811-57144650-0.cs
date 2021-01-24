          PdfPage page2 = doc.Pages[countMessages-1];
          PdfTemplate customFooter = doc.AddTemplate(
          page2.PageSize.Width, 30);
          PdfHtmlElement customHtml = new PdfHtmlElement(
          $"showing {countMessages} from {totalNumMessages} messages",
          string.Empty);
          customFooter.Add(customHtml);
          page.CustomFooter = customFooter;
