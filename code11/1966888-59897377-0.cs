     public ActionResult NewPicture(int tid)
    
        {
            var response = service.Get(tid);
            if (!response.Succeed)
               return Error(response.MainError.ErrorType);
            return ManagementView("/Gallery/EditPicture.cshtml", new PictureSaveViewModel() { Id = 0, GalleryId = tid });
        }
