    public void HidePanelsRecursively(Control container)
    {
        if (container is Panel)
            container.Visible = false;
     
        foreach (Control ctrl in container.Controls)
            HidePanelsRecursively(ctrl);
    }
