    lblDescription.Text = response.Policy.Description;
    IHasReg hasReg = response.Policy as IHasReg;
    if (hasReg != null) lblReg.Text = hasReg.Reg;
    IHasContents hasContents = response.Policy as IHasContents;
    if (hasContents != null) lblContents.Text = hasContents.Contents;
