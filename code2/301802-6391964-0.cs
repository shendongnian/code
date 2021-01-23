    public interface ICommand
    {
        string Name {get;set;}
        bool Enabled { get; set; }
        bool Checked { get; set; }
    
        void OnClick();
    }
