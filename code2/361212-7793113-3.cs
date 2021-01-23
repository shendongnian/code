    class RegistrationInfo
    {
    }
    class RegistrationInfo1 : RegistrationInfo
    {
        public string Arg;
    }
    class RegistrationInfo2 : RegistrationInfo
    {
        public int Arg;
    }
    interface IBase<in TRegistration>
        where TRegistration : RegistrationInfo
    {
        void Register(TRegistration registration);
    }
    class Base : IBase<RegistrationInfo>
    {
        public void Register(RegistrationInfo registration)
        {
        }
    }
    class Registrar1 : IBase<RegistrationInfo1>
    {
        public void Register(RegistrationInfo1 arg)
        {
        }
    }
    class Registrar2 : IBase<RegistrationInfo2>
    {
        public void Register(RegistrationInfo2 arg)
        {
        }
    }
