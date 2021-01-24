    public string Tags
        {
            get
            {
                return TagsList != null
                    ? String.Join(" ", TagsList.Select(tag => tag ))
                    : null;
            }
            set
            {
                TagsList = !String.IsNullOrWhiteSpace(value)
                    ? value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                    : new List<string>();
            }
        }
    [NotMapped]
    public List<string> TagsList { get; set; }
