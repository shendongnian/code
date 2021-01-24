    [TestFixture]
    public class DirectSoundTests
    {
        [Test]
        [Category("IntegrationTest")]
        public void CanEnumerateDevices()
        {
            foreach(var device in DirectSoundOut.Devices)
            {
                 Debug.WriteLine(String.Format("{0} {1} {2}", device.Description, device.ModuleName, device.Guid));
             }
          }
    }
