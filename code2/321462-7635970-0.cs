            HtmlElementCollection inputColl = HTMLDoc.GetElementsByTagName("input");
            foreach (HtmlElement inputTag in inputColl)
            {
                string valueAttribute = inputTag.GetAttribute("value");
                if (valueAttribute.ToLower() == "sign up")
                {
                    inputTag.Focus();
                    IHTMLElement nativeElement = el.DomElement as IHTMLElement;
                    nativeElement.click();
                    break;
                }
            }
