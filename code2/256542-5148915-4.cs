    HomeworkAssignments          Questions                      Answers
    *******************          *********                      *******
    HomeworkAssignmentId (pk)    QuestionId (pk)                AnswerId (pk)
    ...                          HomeworkAssignmentId (fk)      QuestionId (fk)
                                 ...                            StudentId (fk)
                                                                ...
    StudentHomeworkAssignmentRelations    TeacherHomeworkAssignmentRelations
    **********************************    **********************************
    StudentId (fk)                        Teacherid (fk)
    HomeworkAssignmentId (fk)             HomeworkAssignmentId (fk)
