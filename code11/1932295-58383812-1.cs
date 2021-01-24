    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<Student> students = Student.GetStudents(FILENAME);
                DataTable dt = Student.CreateTable(students);
            }
        }
        public class Student
        {
            public string Name { get; set; }
            public string Year { get; set; }
            public int? intTotalMarks { get; set; }
            public List<TotalMarks> totalMarks { get; set; }
            public static List<Student> GetStudents(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                List<Student> students = new List<Student>();
                foreach (XElement xStudent in doc.Descendants("Student"))
                {
                    Student student = new Student();
                    students.Add(student);
                    student.Name = (string)xStudent.Element("Name");
                    student.Year = (string)xStudent.Element("Year");
                    XElement xMarks = xStudent.Element("TotalMarks");
                    if (xMarks.HasElements)
                    {
                        foreach (XElement table in xStudent.Descendants("Table"))
                        {
                            TotalMarks totalMarks = new TotalMarks();
                            if (student.totalMarks == null) student.totalMarks = new List<TotalMarks>();
                            student.totalMarks.Add(totalMarks);
                            totalMarks.mode = (string)table.Attribute("Mode");
                            totalMarks.marks = table.Elements("Item").Select(x => new Mark()
                            {
                                mark = (int)x.Attribute("Marks"),
                                result = (decimal)x.Attribute("Result")
                            }).ToList();
                        }
                    }
                    else
                    {
                        student.intTotalMarks = (int)xMarks;
                    }
                }
                return students;
            }
            public static DataTable CreateTable(List<Student> students)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Year", typeof(string));
                dt.Columns.Add("Mode", typeof(string));
                dt.Columns.Add("Mark", typeof(int));
                dt.Columns.Add("Result", typeof(decimal));
                foreach(Student student in students)
                {
                    if (student.totalMarks == null)
                    {
                        dt.Rows.Add(new object[] {
                                student.Name,
                                student.Year,
                                null,
                                student.intTotalMarks
                        });
                    }
                    else
                    {
                        foreach (TotalMarks totalMark in student.totalMarks)
                        {
                            foreach (Mark mark in totalMark.marks)
                            {
                                dt.Rows.Add(new object[] {
                                student.Name,
                                student.Year,
                                totalMark.mode,
                                mark.mark,
                                mark.result
                            });
                            }
                        }
                    }
                        
                }
                return dt;
            }
        }
        public class TotalMarks
        {
            public string mode { get; set; }
            public List<Mark> marks { get; set; }
        }
        public class Mark
        {
            public int mark { get; set; }
            public decimal result { get; set; }
        }
    }
