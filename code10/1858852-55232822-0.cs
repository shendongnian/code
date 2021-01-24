    public ActionResult GetTextFile()
    {
        var topFiveStudents = db.Students.OrderByDescending(s => s.SumNote).Take(5).ToList();
    
        if (topFiveStudents != null && topFiveStudents.Count > 0) 
        {
            string fileName = "something.txt";
    
            // create a stream
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            foreach (var students in topFiveStudents)
            {
                // iterate the list and write to stream
                sw.WriteLine(string.Format("{0}, Sum of notes: {1}", students.Name, students.SumNote));
            }
            sw.Flush();
            ms.Position = 0;
    
            // return text file from stream
            return File(ms, "text/plain", fileName);
        }
        else
        {
            // do something else
        }
    }
