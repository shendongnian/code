    public ActionResult Rate([Bind(Exclude="Score")]RatingModel model)
    {    
        model.Score = ParseScore( Request.Form("score"));
        if(TryValidateModel(model))
        {
            ///validated with all validations
        }
    }
