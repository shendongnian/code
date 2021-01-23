            public string Name { get {
            if (null != FriendlyName)
                return FriendlyName;
            else
                return Name;//error, you're calling the property getter again.
            }
