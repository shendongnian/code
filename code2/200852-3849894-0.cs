    var player = new AudioPlayer
    {
        Car = new Car()
        {
            WheelSize = new Inch(21),
            Driver = new Person()
            {
                Age = 53,
                Type = LicenseType.B,
                Family =
                {
                    new Person("Jane"),
                    new Person("Pieter"),
                    new Person("Anny")
                }
            }
        }
        Directory = vc.Directory,
        StartTime = vc.StarTime,
        EndTime = vc.EndTime
    };
