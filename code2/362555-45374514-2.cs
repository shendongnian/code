       static void Main(string[] args)
        {
            IInform objInform = new ImplementInform();
            objInform.Inform +=new EventHandler(Informed);
            objInform.InformNow();
            Console.ReadLine();
        }
        private static void Informed(object sender, EventArgs e)
        {
            Console.WriteLine("Informed");
        }
