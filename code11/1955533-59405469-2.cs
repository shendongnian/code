    var appointmentData = System.IO.File.ReadAllText("Data/AppointmentSeed.json");
                var appointmentVMs = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(appointmentData);
                foreach (var appointment in appointmentVMs)
                {
                    var departmentId = context.Departments.SingleOrDefault(d => d.Name == appointment.Type).Id;
                    Appointment model = new Appointment();
                    
                    model.AppointmentDate = appointment.AppointmentDate;
                    model.Status = appointment.Status;
                    model.DoctorId = context.Doctors.SingleOrDefault(d => d.Name == appointment.DoctorName && d.DepartmentId == departmentId).Id;
                    model.PatientId = context.Patients.SingleOrDefault(p => p.IdentityNumber == appointment.PatientIdentityName).Id;
                    context.Appointments.Add(model);
                }
                context.SaveChanges();
