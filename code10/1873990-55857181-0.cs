    class Person{
        public string name;
        public float age;
    
        public string createdBy;
        public string GetValue(){
            return (name + " " + age.ToString());
        }
    }
    static void Main(){
        Person p1 = new Person();
		p1.age = 0; 
		p1.name = "hello";
		p1.createdBy = "no-one";
		Person p2 = new Person();
		p2.age = 0;
		p2.name = "hello";
		p2.createdBy = "me";
		if (p1.GetValue() == p2.GetValue())
			Console.WriteLine("hello");
