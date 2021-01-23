      class personInfo
    {
        public string fName;
        public string lName;
        public int personID;
    }
    class Program
    {
        static void Main(string[] args)
        {
            personInfo InfoPeople = new personInfo();
            InfoPeople.fName = "jeff";
            Console.WriteLine("the fName is: " + " " + InfoPeople.fName);
        }
    }
