c#
 public ActionResult<List<string>> GetSciptTags_config(int ConfigID)
        {
            List<TblLibrary> LibraryRecsToScript = new List<TblLibrary>();
            // Get a list of libraries in the project config
            List<TblProjectConfigLibraries> configLibraries = db.TblProjectConfigLibraries.Where(s => s.ConfigurationId == ConfigID).ToList();
            foreach (TblProjectConfigLibraries configLibRec in configLibraries)
            {
                LibraryRecsToScript.AddRange(GetLibraryList(configLibRec.LibraryId));
            }
            // Get Scripts
            List<string> scripts = getScriptTags(LibraryRecsToScript);
            return scripts;
        }
This will then add the tblLibrary object to an external list called librariesSeen, and for each call, check to see if it has already been added to librariesSeen to stop infinite looping.
c#
 private List<TblLibrary> GetLibraryList(int libraryID)
        {
            List<TblLibrary> retVal = new List<TblLibrary>();
            // master list of records found is a class wide variable so that this routine can be called from within itself
            TblLibrary libRec = db.TblLibrary.FirstOrDefault(s=> s.Id == libraryID);
            librariesSeen.Add(libRec);
            if (retVal.Contains(libRec) == false)
            {
                List<TblLibraryRequirements> requirementsFound = db.TblLibraryRequirements.Where(s => s.LibraryId == libraryID).ToList();
                foreach (TblLibraryRequirements req in requirementsFound)
                {
                    TblLibrary reqLibRecord = db.TblLibrary.FirstOrDefault(s => s.Id == req.RequiresId);
                    if (librariesSeen.Contains(reqLibRecord) == false)
                    {
                        retVal.AddRange(GetLibraryList(reqLibRecord.Id));
                    }
                }
                retVal.Add(libRec);
                // Remove Duplicates
                retVal = retVal.Distinct().ToList();
            }
            return retVal;
        }
Hope this helps someone else =)
