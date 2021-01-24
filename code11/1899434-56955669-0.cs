     var badgesList =
                from bad in db.BadgeAssignments
                join coh in db.CohortProgramEnrollment on bad.CohortProgramEnrollmentID equals coh.ID
                join des in db.Badges on bad.BadgeID equals des.ID
                where bad.BadgeID == CohortProgramEnrollmentID
                select new { Badges = des };
    
            return Json(badgesList.ToList().Select(x => new { 
                 x.Badges.CohortProgramEnrollmentID, x.Badges.Description }),
                        JsonRequestBehavior.AllowGet);
        }
