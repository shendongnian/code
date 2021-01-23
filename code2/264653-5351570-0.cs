    private void UpdateTags(Control page)
        {
            foreach (Control ctrl in page.Controls)
            {
                if (ctrl is HtmlAnchor)
                {
                    ((HtmlAnchor)ctrl).HRef = "myNewlink";
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        UpdateTags(ctrl);
                    }
                }
            }
        }
