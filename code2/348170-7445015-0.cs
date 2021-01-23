    var meeting = _repository.GetMeetingById(meetingId);
    var dto = new MeetingDto();
    dto.Begins = meeting.Begins;
    dto.End = meeting.End;
    dto.Attendees = meeting.Attendees;
    dto.AttendeesCount = meeting.Attendees.Count;
    //do something meaningful
