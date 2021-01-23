    namespace TeacherBook {
        public partial class ChooseGrade : Form {
            public int[] grad_class=new int[2]; //int array for grade & class (first for Grade,second for class) 
            EditStudent StdForm = new EditStudent();
        }
    namespace TeacherBook {
        public partial class EditStudent : Form {
            ChooseGrade ChGrade = new ChooseGrade(); // define form 
        }
    }
