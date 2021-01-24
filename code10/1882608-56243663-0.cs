    IQueryable<Appointment> Appointments;
            // Does not affect your slowness issue.
            Appointments = condition1 ? _context.Appointment.Where(somecondition) : _context.Appointment.Where(othercondition);
            AppointmentsData = Appointments
                               .Join(_context.Patient,
                                     appPatientKey => appPatientKey.Id, // The primary key of Appointments.
                                     patientKey => patientKey.Id,         // The primary key of Patient.
                                     (appPatientKey, patientKey) => new {
                                         Appointments = appPatientKey,
                                         Patient = patientKey
                                     })
                                .Join(_context.Doctor,
                                      appPatientKey => appPatientKey.IdDoctor, // Assuming that the IdDoctor is coming from Appointments
                                      doctorKey => doctorKey.Id,
                                      (appPatientKey, doctorKey) => new {
                                          appPatientKey.Appointments,
                                          appPatientKey.Patient,
                                          Doctor = doctorKey
                                      })
                                ... // other Joins
                                .GroupBy(result => { AppointmentId = result.Appointments.id, PatientFullName = result.Patient.Fullname, DoctorFullName = result.Doctor.FullName...})
                                .Select(theEntity => new Models.AppointmentData()
                                {
                                    Id = AppointmentId,
						            Patient = PatientFullName,
						            Doctor = DoctorFullName
                                }).ToList();
