    public class StudentInfoCsv
    {
        public Student Student {get;set;}
        public string Courses { get; set; }
    }
    
    List<StudentInfoCsv> csvData = new List<StudentInfoCsv>
    foreach(var item in records)
    {
    	StudentInfoCsv.Add(new StudentInfoCsv()
    	{
    		Student = item.Student,
    		Courses = CsvSerializer.SerializeToCsv(item.Courses)
    	}
    }
    csvWriter.WriteRecords(csvData);
