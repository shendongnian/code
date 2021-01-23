    public ActionResult TvCreate(TvNewsVideoVM modelVM)
    {
       ModelState.Clear();
       if (modelVM.CurrentStep == NewsWizardStep.Two)
       {
         var sessionModel = ((TvNewsVideoVM)Session["TvModelVM"]);
    
         modelVM.VideoClip = sessionModel.VideoClip;
         modelVM.VideoThumbnail = sessionModel.VideoThumbnail;
       }
    
       if (TryValidateModel(modelVM))
       {
         ...
       }
    }
