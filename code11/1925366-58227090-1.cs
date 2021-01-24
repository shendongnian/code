    var x = new X
    {
        Ys = new Y[] {
            new Y {
                Zs = new Z[] { new Z { } }
            },
            new Y {
                Zs = new Z[] {
                    new Z { },
                    new Z {
                        A = 1,
                        Bs = new int[] { 0, 1, 2, 3 }
                    }
                }
            }
        }
    };
    string query = QueryStringSerializer.ToQueryString(x);
