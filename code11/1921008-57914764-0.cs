               //Example 1
                HtmlAnchor ct = (HtmlAnchor)FindControl("CRM1");
                ct.Attributes.Add("href", "~/Test.aspx");
                //Example 2
                HtmlControl ct2 = (HtmlControl)Page.Master.FindControl("CRM2");
                ct2.Attributes.Add("href", "~/Test.aspx");
