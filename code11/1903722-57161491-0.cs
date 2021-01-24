    int counter = 0;
    foreach(HtmlElement btn in webBrowser1.Document.GetElementsByTagName("button"))
    {
        if (btn.GetAttribute("className") == "g56EM  _7_FaD")
        {
            counter++;
            if (counter == 1)
            {
                btn.InvokeMember("Click");
                break;
            }
        }
    }
