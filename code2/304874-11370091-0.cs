    public class PatientAppointmentRepository : IPatientAppointmentRepository
    {
        //Injected via IOC in constructor
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientAppointmentLogic _patientAppointmentLogic;
        public void CreateAppointment(PatientAppointmentModel model)
        {
            var appointment = ModelMapper.Instance.To<PatientAppointment>(model);
            
            var appointmentAdded = _patientAppointmentLogic.Add(appointment);
            if(appointmentAdded)
                _unitOfWork.SaveChanges();
        }
    }
    public class PatientAppointmentLogic : IPatientAppointmentLogic
    {
        private readonly IUnitOfWork _unitOfWork; //Set via constructor
        private readonly PatientLogic _patientLogic;
        public bool Validate(PatientAppointment appointment)
        {
            if(appointment == null)
                throw new ArgumentNullException("appointment");
            //perform some logic here
            return true;
        }
        public void Add(PatientAppointment appointment)
        {
            if(appointment == null)
                throw new ArgumentNullException("appointment");
    
            if(!Validate(appointment)) return; //Or throw an exception, up to you
            var patient = _patientLogic.GetById(appointment.PatientId);
            
            if(patient == null) return;
            patient.PatientAppointments.Add(appointment);
        }
    }
