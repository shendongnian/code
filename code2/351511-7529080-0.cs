    FileUpload fu1 = (FileUpload)FindControl(DetailsView1, "FileUpload1");
    ...
    private Control FindControl(Control parent, string id)
    {
        foreach (Control child in parent.Controls)
        {
            string childId = string.Empty;
            if (child.ID != null)
            {
                childId = child.ID;
            }
            if (childId.ToLower() == id.ToLower())
            {
                return child;
            }
            else
            {
                if (child.HasControls())
                {
                    Control response = FindControl(child, id);
                    if (response != null)
                        return response;
                }
            }
        }
        return null;
    }
