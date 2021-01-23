            List<tbltask> tbtask = new List<tbltask>();
            var selectproject = entity.tbluserprojects.Where(x => x.user_id == userid).Select(x => x.Projectid);
            if (statusid != "" && ProjectID != "" && a != "" && StartDate != "" && EndDate != "")
            {
                int pid = Convert.ToInt32(ProjectID);
                int sid = Convert.ToInt32(statusid);
                DateTime sdate = Convert.ToDateTime(StartDate).Date;
                DateTime edate = Convert.ToDateTime(EndDate).Date;
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.tblproject.ProjectId == pid) && (x.tblstatu.StatusId == sid) && (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a)) && (x.StartDate >= sdate && x.EndDate <= edate)).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (statusid == "" && ProjectID != "" && a != "" && StartDate != "" && EndDate != "")
            {
                int pid = Convert.ToInt32(ProjectID);
                DateTime sdate = Convert.ToDateTime(StartDate).Date;
                DateTime edate = Convert.ToDateTime(EndDate).Date;
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.tblproject.ProjectId == pid) && (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a)) && (x.StartDate >= sdate && x.EndDate <= edate)).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (ProjectID == "" && statusid != "" && a != "" && StartDate != "" && EndDate != "")
            {
                int sid = Convert.ToInt32(statusid);
                DateTime sdate = Convert.ToDateTime(StartDate).Date;
                DateTime edate = Convert.ToDateTime(EndDate).Date;
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.tblstatu.StatusId == sid) && (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a)) && (x.StartDate >= sdate && x.EndDate <= edate)).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if(ProjectID!="" && StartDate == "" && EndDate == "" && statusid == ""  && a == "")
            {
                int pid = Convert.ToInt32(ProjectID);
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.tblproject.ProjectId == pid)).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if(statusid!="" && ProjectID=="" && StartDate == "" && EndDate == ""  && a == "")
            {
                int sid = Convert.ToInt32(statusid);
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.tblstatu.StatusId == sid) ).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (a == "" && StartDate != "" && EndDate != "" && ProjectID != "")
            {
                int pid = Convert.ToInt32(ProjectID);
                DateTime sdate = Convert.ToDateTime(StartDate).Date;
                DateTime edate = Convert.ToDateTime(EndDate).Date;
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.ProjectId == pid) && (x.StartDate >= sdate && x.EndDate <= edate)).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (StartDate == "" && EndDate == "" && statusid != "" && ProjectID != "" && a != "")
            {
                int pid = Convert.ToInt32(ProjectID);
                int sid = Convert.ToInt32(statusid);
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.tblproject.ProjectId == pid) && (x.tblstatu.StatusId == sid) && (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a))).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (a == "" && StartDate == "" && EndDate == "" && ProjectID != "" && statusid != "")
            {
                int pid = Convert.ToInt32(ProjectID);
                int sid = Convert.ToInt32(statusid);
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Include(x => x.tblstatu).Where(x => selectproject.Contains(x.ProjectId) && x.tblproject.company_id == c && x.tblproject.ProjectId == pid && x.tblstatu.StatusId == sid).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (a != "" && StartDate == "" && EndDate == "" && ProjectID == "" && statusid == "")
            {
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a))).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (a != "" && ProjectID != "" && StartDate == "" && EndDate == "" && statusid == "")
            {
                int pid = Convert.ToInt32(ProjectID);
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.tblproject.ProjectId == pid) && (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a))).OrderByDescending(x => x.ProjectId).ToList();
            }
            else if (a != "" && StartDate != "" && EndDate != "" && ProjectID == "" && statusid == "")
            {
                DateTime sdate = Convert.ToDateTime(StartDate).Date;
                DateTime edate = Convert.ToDateTime(EndDate).Date;
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && (x.tblproject.company_id == c) && (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a)) && (x.StartDate >= sdate && x.EndDate <= edate)).OrderByDescending(x => x.ProjectId).ToList();
            }
            else
            {
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).Where(x => selectproject.Contains(x.ProjectId) && x.tblproject.company_id == c).OrderByDescending(x => x.ProjectId).ToList();
            }
            return tbtask;
        }
