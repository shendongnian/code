    var as_tv = new DeviceParameter() {
        Key = "testkey",
        DeviceId = new Guid(),
        Value = "Armed"
    };
    var asp = new ArmingStatusParameter();
    IDeviceValueTypedDeviceParameter<ArmingStatuses> iasp = asp;
    if (DeviceValueTypedParameterConverter.TryConvert<ArmingStatuses>(as_tv, ref iasp)) {
        // work with asp
    }
    var po_tv = new DeviceParameter() {
        Key = "testkey2",
        DeviceId = new Guid(),
        Value = "4/15/2019 17:36"
    };
    var pop = new PoweredOnStatusParameter();
    IDeviceValueTypedDeviceParameter<DateTime> ipop = pop;
    if (DeviceValueTypedParameterConverter.TryConvert<DateTime>(po_tv, ref ipop)) {
        // work with pop
    }
    var v_tv = new DeviceParameter() {
        Key = "testkey3",
        DeviceId = new Guid(),
        Value = "17"
    };
    var vp = new VoltageStatusParameter();
    IDeviceValueTypedDeviceParameter<int> ivp = vp;
    if (DeviceValueTypedParameterConverter.TryConvert<int>(v_tv, ref ivp)) {
        // work with vp
    }
