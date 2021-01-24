    public IQueryable GetAllMeeting()
            {
                var allMeeting = from xx in _dbContext.tbl_Meeting
                        let meetingCreatedBy = _dbContext.tbl_User.FirstOrDefault(x=>x.Id == xx.CreatedById)
                                 select new Meeting
                                 {
                                     Meeting_Attendee_Id = xx.Attendees,
                                     Meeting_Agenda = xx.Agenda,
                                     Meeting_Date = xx.Date,
                                     Id = xx.Id,
                                     Meeting_Subject = xx.Subject,
                                     CreatedById = xx.Created_By,
                                     CreatedBy = meetingCreatedBy !=null ? meetingCreatedBy.Name : "" //Or whatever property/column you have for displaying the name
                                 };
                  return allMeeting;
            }
