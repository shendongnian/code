    public class IdModel
    {
        public string Id { get; set; }
        public string FolderId { get; set; }
        public int Value
        {
            get
            {
                if (int.TryParse(Id, out int value))
                {
                    return value;
                }
                else if (int.TryParse(FolderId, out value))
                {
                    return value;
                }
                else
                {
                    throw new Exception("This model has no valid id");
                }
            }
        }
    }
