c#
//Asker relation
builder.Entity<QuestionModel>()
           .HasOne(q=> q.Asker)
           .Withmany(u => u.AskedQuestions)
           .HasForeignKey(q=> q.AskerId)
           .HasConstraintName("ForeignKey_Asker_QuestionAsked")
           .IsRequired(true);
//Asked relation
builder.Entity<QuestionModel>()
           .HasOne(q=> q.AskedUser)
           .Withmany()
           .HasForeignKey(q=> q.AskeduserId)
           .HasConstraintName("ForeignKey_User_AskedQuestion")
           .IsRequired(true);
I use Fluent API on dependant model instead of the root element.
