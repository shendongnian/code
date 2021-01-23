    class CommitCommand
    {
        public string Message { get; set; }
        public bool AddRemove { get; set; }
        public List<string> Arguments = new List<string>();
    }
    Repo.Execute(new CommitCommand
    {
        Message = "Your commit message",
        AddRemove = true,
        Arguments = { "--my-commit-extension", "--my-other-commit-extension" }
    });
