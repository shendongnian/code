    public class StudentController : Controller
    {
        public StudentModel[] S;
        public StudentController()
        {
            S = new StudentModel[5];
            S[0] = new StudentModel;
            S[0].SetInfo("Harry", "Potter", 3.0);
        }
        ... your actions
    }
