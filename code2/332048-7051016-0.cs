    public struct StudentDetails
    {
        public string unitCode; //eg CSC10208
        public string unitNumber; //unique identifier
        public string firstName; //first name
        public string lastName;// last or family name
        public int studentMark; //student mark
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", unitCode,
                   unitNumber,firstName,lastName,studentMark);
        }
    }
