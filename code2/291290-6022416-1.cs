    var startingIssue = db.Issues.Find(issue.IssueId);
    if (ModelState.IsValid)
    {
        if (issue.CreatedBy != startingIssue.CreatedBy) issue.CreatedBy = startingIssue.CreatedBy;
        if (issue.CreatedDate != startingIssue.CreatedDate) issue.CreatedDate = startingIssue.CreatedDate;
        issue.LastActivity = (DateTime?)DateTime.Now.Date;
        if (issue.ClosedBy != null) issue.ClosedDate = (DateTime?)DateTime.Now.Date;
        // startingIssue = null;
        db.Detach(startingIssue);
        db.Entry(issue).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
