    using ExportDllAttribute.DllExport;
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct StudentsStruct
    {
        public string Name;
        public int SomeInt;
        public double SomeDouble;
    
        [DllExport]
        public static int GetStudentsList([Out] out StudentsStruct[] students)
        {
            students = new StudentsStruct[] { new StudentsStruct { Name = "Satan", SomeInt = 666, SomeDouble = 666 },
                    new StudentsStruct { Name = "Techno", SomeInt = 777, SomeDouble = 777 } };
            return students.Length;
        }
    }
