    public Student Calc_HighestMarkOutput()
    {
        var result = new Student(); // You also might have to add a default constructor.
        foreach (Student student in myStudents) {
            if (student.Maths_Result > result.Maths_Result) {
                result.Maths_Result = student.Maths_Result;
            }
            if (student.English_Result > result.English_Result) {
                result.English_Result = student.English_Result;
            }
            if (student.Maltese_Result > result.Maltese_Result) {
                result.Maltese_Result = student.Maltese_Result;
            }
        }
        return result;
    }
