<img src="Competition/ViewJobDescription?competitionId=1234" />
        public ActionResult ViewJobDescription(int competitionId)
        {
            string errorMsg = "";
            var competition = new DBModel.Competition();
            try
            {               
                competition = DBModel.Competition.GetCompetition(competitionId);
                if (competition != null && competition.AttachmentContent != null)
                {
                    byte[] fileData = competition.AttachmentContent;
                    string filename = competition.AttachmentTitle + ".pdf";
                    return File(fileData, "application/pdf", filename);
                }
            }
            catch (Exception ex)
            {
                errorMsg += "An error occured: " + ex.Message;
                LogFile err = new LogFile();
                err.CreateErrorLog(errorMsg);
                ModelState.AddModelError(string.Empty, errorMsg);
            }
            return RedirectToAction("Index", "Home");
        }
