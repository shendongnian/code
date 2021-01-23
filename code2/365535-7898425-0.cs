    IEnumerable<Exam> GetExams() {
        return _db.Exams.Select(e => CreateExamById(e);
    }
    IEnumerable<Exam> GetExamWithAttendees(long examId) {
        return _db.Exams.Select(e => CreateExamById(e, examId);
    }
    
    Exam CreateExamById(Exam exam, long examId=0){
        return new Exam {
            CourseName = exam.Course.Name,
            Date = exam.Date,
            Attendees = e.Attendees.Select(a => a..... == examId ...)
        };
    }
