    class intefacehierarchy:two,one
    {
    
        string name;
        // implements two.getdata
        public void getdata()
        {
    
            Console.WriteLine("ok tell me your name");
        }
    
        // implements one.getdata explicitly
        void one.getdata()
        {
            Console.WriteLine("Enter the name");
            name = Console.ReadLine();
        }
        // implements two.showdata
        public void showdata()
        {
            Console.WriteLine(String.Format("hello mr. {0}", name));
    
        }
    
    }
