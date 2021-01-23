            var clonedwebpage = ((Entity)webpage).Clone(true);
            clonedwebpage.Id = Guid.NewGuid();
            clonedwebpage.Attributes.Remove("adx_webpageid");
            //clonedwebpage.Attributes.Remove("adx_pagetemplateid");
            clonedwebpage.EntityState = null;
            clonedwebpage["adx_websiteid"] = new EntityReference("adx_webpage",livesiteGuid);
            //clonedwebpage["adx_parentpageid"] = 
            // create the template guid
            Guid tempGuid = new Guid(templateguid);
            clonedwebpage["adx_pagetemplateid"] = new EntityReference("adx_pagetemplate",tempGuid); // set the template of the new clone
            //serviceContext.Attach(cloned);
            //serviceContext.MergeOption = MergeOption.NoTracking;
            Guid clonedwebpageguid = _service.Create(clonedwebpage);
             //var webpage = serviceContext.Adx_webpageSet.Where(wp => wp.Id == webpageguid).First();
            //var notes_webile = serviceContext.Adx_webfileSet.Where(wf => wf.
            //*********************************** WEB FILE *********************************************
            foreach (var webfile in webpage.adx_webpage_webfile)
            {
                var cloned_webfile = webfile.Clone(); 
                //should iterate through every web file that is related to a web page, and clone it. 
                cloned_webfile.Attributes.Remove("adx_webfileid");
                cloned_webfile.Attributes.Remove("adx_websiteid");
                cloned_webfile.Attributes.Remove("adx_parentpageid");
                cloned_webfile["adx_websiteid"] = new EntityReference("adx_website", livesiteGuid);
                cloned_webfile["adx_parentpageid"] = new EntityReference("adx_webpage", clonedwebpageguid);
                cloned_webfile.EntityState = null;
                cloned_webfile.Id = Guid.NewGuid();
                Guid ClonedWebFileGuid = _service.Create(cloned_webfile);
                //*********************************** NOTE *********************************************
                foreach (var note in webfile.adx_webfile_Annotations)
                {
                    var cloned_note = note.Clone();
                    cloned_note.Attributes.Remove("annotationid"); // pk of note
                    cloned_note.Attributes.Remove("objectid"); // set to web file guid
                    cloned_note["objectid"] = new EntityReference("adx_webfile", ClonedWebFileGuid); // set the relationship between our newly cloned webfile and the note
                    cloned_note.Id = Guid.NewGuid();
                    cloned_note.EntityState = null;
                    Guid clonednote = _service.Create(cloned_note);
                    //cloned_note.Attributes.Remove("ownerid");
                    //cloned_note.Attributes.Remove("owningbusinessunit");
                    //cloned_note.Attributes.Remove("owningteam");
                    //cloned_note.Attributes.Remove("owninguser");
                }
