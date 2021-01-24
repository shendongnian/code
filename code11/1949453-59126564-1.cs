    public class DB
    {
        public IEnumerable<Speciality> Specialities
        {
            get
            {
                return new List<Speciality>()
                {
                    new Speciality(){ Id= 1, Name ="S1"},
                    new Speciality(){ Id= 2, Name ="S2"},
                    new Speciality(){ Id= 3, Name ="S3"},
                };
            }
        }
        public IEnumerable<Doctor> Doctors
        {
            get
            {
                return new List<Doctor>()
                {
                    new Doctor(){ Id= 1, Name ="D1", SpecialityId = 1},
                    new Doctor(){ Id= 2, Name ="D2", SpecialityId = 2},
                    new Doctor(){ Id= 3, Name ="D3", SpecialityId = 2},
                    new Doctor(){ Id= 4, Name ="D4", SpecialityId = 3},
                    new Doctor(){ Id= 5, Name ="D5", SpecialityId = 3},
                    new Doctor(){ Id= 6, Name ="D6", SpecialityId = 3},
                };
            }
        }
    }
