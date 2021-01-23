    context.Complaints.AddObject(complaint);
    
    if (CompletedCheckBox.Checked)
        {
            
            complaint.Status = ComplaintStatus.GetStatusCode("Completed");
            context.SaveChanges();
            var solution = new Solution
                               {
                                   CreatedBy = CurrentUser.UserID,
                                   CreatedDate = DateTime.Now,
                                   SolutionDesc = DescriptionTextBox.Text,
                                   ComplaintId = complaint.Id
                               };            
            context.Solutions.AddObject(solution);
        }
            
            if(context.SaveChanges() > 0)
            {
                ResetFrom();
                return true;
            }
        
