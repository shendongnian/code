    class Model
            {
                public string Id { get; set; }
                public int? FolderId { get; set; }
                public int RealFolderId
                {
                    get
                    {
                        if (FolderId != null)
                        {
                            return FolderId.Value;
                        }
                        int id;
                        if (int.TryParse(Id, out id))
                        {
                            return id;
                        }
                        throw new Exception("This explodes");
                    }
                }
            }
