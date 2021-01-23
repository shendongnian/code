     StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<Student, List<Subject>> item in studentLists)
        {
            sb.Append("Student No : " + item.Key.RollNo + "<br />");
            sb.Append("Student Name : " + item.Key.Name + "<br />");
            foreach (var subjects in item.Value)
            {
                sb.Append("Subject No : " + subjects.SubjectNo + "<br />");
                sb.Append("Subject Name : " + subjects.Type + "<br />");
            }
        }
