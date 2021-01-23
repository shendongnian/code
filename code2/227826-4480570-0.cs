     var l = new List<char>();
                l.AddRange(Path.GetInvalidFileNameChars());
                l.AddRange(Path.GetInvalidPathChars());
    
                this.KeyPress += (obj, sender) =>
                    {
                        if (l.Where(x => x == sender.KeyChar).Count() > 0)
                        {
                            sender.Handled = true;
                        }
    
                    };
