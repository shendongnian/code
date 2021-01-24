    public class PhoneTypeChecker
    {
        private readonly IManufacturer mfg;
        public PhoneTypeChecker( IManufacturer mfg )
        {
            this.mfg = mfg ?? throw new ArgumentNullExceptio(nameof(mfg));
        }
        public void CheckProducts()
        {
            Console.WriteLine( this.mfg.Name + ":\nSmart Phone: " + 
        this.mfg.PhoneFactory.GetSmart().Name() + "\nDumb Phone: " + this.mfg.PhoneFactory.GetDumb().Name() );
        }
    }
