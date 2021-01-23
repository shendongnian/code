        if (DataList1.Items.Count == 0)
            {
                msgError.Text = "Please add images and captions for each image";
                msgError.Focus();
            }
        else 
            AddCaption();
            bool IsEmptyCaption = false;
            Hashtable htble = (Hashtable)ViewState["imgIdCapHtbl"];
            List<int> imgIds = (List<int>)ViewState["imgIds"];
            if (htble != null && imgIds != null)
            {
                foreach (int id in imgIds)
                {
                    if (htble[id] == "" || htble[id] == null) // New code implemented here
                    {
                        IsEmptyCaption = true;
                        break;
                    }
                    else
                        IsEmptyCaption = false;
                }
            }
            else
                IsEmptyCaption = true;
           if (DataList1.Items.Count == 0)
            {
                msgError.Text = "Please add images";
                msgError.Focus();
            }
            else if (IsEmptyCaption)
            {
                msgError.Text = "Please add captions for each image";
                msgError.Focus();
            }
            else
            {
                Args[0] = "Section1";
                Args[1] = "";
                Args[2] = FindingId.ToString();
                Args[3] = FindingIdIns.ToString();
                AnotherHeading = false;
                //AddCaption();
                objGetBaseCase.UpdateImageCaptions((Hashtable)ViewState["imgIdCapHtbl"]);
                if (AddFindingsViewerDetails != null)
                    AddFindingsViewerDetails(Args, e);
                ClearImages();
                PageContent pg = (PageContent)this.Parent.FindControl("PageContent");
                if (pg != null)
                    pg.LoadWorkflowForCase();
                if (Display != null)
                    Display(null, EventArgs.Empty);
            }
