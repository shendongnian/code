                foreach (HtmlElement element in col)
                {
                    if (element.GetAttribute(attribute).Equals(attName))
                    {
                        // Invoke the "Click" member of the button
                        element.InvokeMember("onclick");
                    }
                }
