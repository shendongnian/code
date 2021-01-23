    public string Name { get {
                if (null != FriendlyName)
                    return FriendlyName;
                else
                    return Name;
                }
                set
                {
                    Name = value;
                }
            }
