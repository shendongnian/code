    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Setup();
        }
        public void Setup()
        {
            System.Diagnostics.Debug.WriteLine("Initialize MTPNordic");
            IS_nRF24L01p.nRF24L01P nRf24 = new nRF24L01P();
            // Use chip select line CS0; SPI speed set to 3 MHz; SPI0 CS0 is 8; Interrupt GPIO selected GPIO 5
            nRf24.InitNordicSPI(new SpiConnectionSettings(0), 3000000, 8, 5); 
        }
    }
