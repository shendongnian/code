    public struct StudentDetails
    {
        public readonly string unitCode; //eg CSC10208
        public readonly string unitNumber; //unique identifier
        public readonly string firstName; //first name
        public readonly string lastName;// last or family name
        public readonly int studentMark; //student mark
        //    use a public constructor to assign the values: required by 'readonly' field modifier
        public StudentDetails(string UnitCode, string UnitNumber, string FirstName, string LastName, int StudentMark)
        {
            this.unitCode = UnitCode;
            this.unitNumber = UnitNumber;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.studentMark = StudentMark;
        }
    }
