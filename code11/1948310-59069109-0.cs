    class Program
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public Program(Guid _ProgramId) {
            this.Id = _ProgramId;
            this.PopulateFields();
        }
        public Program(int _ProgramNumber)
        {
            this.PopulateFields();
        }
        private void PopulateFields()
        {
            this.Title = "New Title";
        }
    }
