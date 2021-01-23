    public interface ICar
    {
        bool EngineLight { get; set; }
        void GetOilChange();
        bool CheckEngineLight();
    }
    public class Car : ICar
    {
        public bool EngineLight { get; set; }
        public virtual void GetOilChange()
        {
        }
        public virtual bool CheckEngineLight()
        {
            if (EngineLight)
            {
                GetOilChange();
                return true;
            }
            return false;
        }
    }
    [TestFixture]
    public class CarTests
    {
        [Test]
        public void WhenEngineLightIsOnGetOilChange()
        {
            MockRepository mocks = new MockRepository();
            Car car;
            using (mocks.Record())
            {
                car = mocks.PartialMock<Car>();
                car.EngineLight = true;
                car.Expect(x => x.GetOilChange())
                    .Repeat.Once()
                    .Message("Should have called GetOilChange");
                    
            }
            using (mocks.Playback())
            {
                var res = car.CheckEngineLight();
                Assert.IsTrue(res);
            }
        }
    }
