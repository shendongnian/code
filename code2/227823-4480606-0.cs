        class ChangeItem
        {
            public string Previous { get; set; }
            public string Current  { get; set; }
            public bool HasDiff { return this.Previous != this.Current; } 
        }
