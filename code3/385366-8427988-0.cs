    [Serializable] class SomeSpecialCar : Cars {
        new public SomeSpecialCar CreateDeepCopy() {
           return (SomeSpecialCar)base.CreateDeepCopy();
        }
    }
