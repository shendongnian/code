    //Appointment Class
        class Appointment
            {
                public string Doctor { get; set; }
                public string Patient { get; set; }
            }
    static void Main(string[] args)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(new Appointment
            {
                Doctor = "doctor1",
                Patient = "patient1"
            });
            appointments.Add(new Appointment
            {
                Doctor = "doctor2",
                Patient = "patient1"
            });
            appointments.Add(new Appointment
            {
                Doctor = "doctor2",
                Patient = "patient2"
            });
            appointments.Add(new Appointment
            {
                Doctor = "doctor2",
                Patient = "patient3"
            });
            appointments.Add(new Appointment
            {
                Doctor = "doctor3",
                Patient = "patient1"
            });
    
            var result = appointments.GroupBy(x => x.Doctor).OrderByDescending(x=>x.Count()).Select(x=>x.Key).FirstOrDefault(); //doctor2
           
    
        }
