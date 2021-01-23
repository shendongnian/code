    class CommandEventArgs : EventArgs
    {
        public DateTime GameTime {get; set; }
        public string Command {get; set;}
        public bool Valid {get; set;}
    }
