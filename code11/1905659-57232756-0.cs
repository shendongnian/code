    public class LowLevelController : ChildController {
        private class I2C {
            public I2C(LowLevelController outerInstance) {
                OuterInstance = outerInstance;
            }
            private LowLevelController OuterInstance { get; }
            private void DoSomething() {
                OuterInstance.Run();
            }
        }
    }
