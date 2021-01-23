    public class Program : IProgram
    {
        ProgramController _controller;
        public Program()
        {
            // pass itself to the controller
            _controller = new ProgramController(this);
        }
        public string FirstName 
        {
            get { return firstNameTextBox.Value; }
            set { firstNameTextBox.Value = value; }
        }
    }
