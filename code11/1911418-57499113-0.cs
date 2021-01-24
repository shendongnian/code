    public int Value {
            get {
                if (Miles > 100)
                {
                    return (Miles - 100);
                }
                else
                {
                    return 0;
                }
            }
        }
