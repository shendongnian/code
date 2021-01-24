    public class Instructors{
     public string SessionName{get;set;}
     public DateTime SessionStartTime {get;set;}
     public string InstructorName {get;set;}
     public string SessionRoom {get;set;}
    }
    List<Instructors>  InstructorsLst=new List<Instructors>();   
    
    foreach (Session S in UpcomingSessions)
    {
     foreach(Enrollment I in S.Instructors())
     {
       Instructors inst=new Instructors();
        inst.SessionName = S.Name;
        inst.SessionStartTime = S.FirstDateTime().ToShortTimeString();
        inst.InstructorName = I.FirstName + " " + I.LastName;
        inst.SessionRoom = S.Room.ToString();
        InstructorsLst.Add(inst);
     }
    }
    lvInstructors.DataSrouce = InstructorsLst;
    lvInstructors.DataBind();
