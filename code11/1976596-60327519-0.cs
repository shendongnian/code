    public class StudentController : Controller
    {
        public StudentController()
        {
            StudentModel[] S = new StudentModel[5];
            S[0] = new StudentModel;
            S[0].SetInfo("Harry", "Potter", 3.0);
        }
        ... your actions
    }
