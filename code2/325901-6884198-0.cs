    public ActionResult Edit(Template ctemplate)
    {
        db.Entry(ctemplate).State = EntityState.Modified;
    	foreach (CorrespondenceRole role in ctemplate.Roles)
    	{
    		//Change role State -> EntityState.Modified
    	}	
        db.SaveChanges();
    }
