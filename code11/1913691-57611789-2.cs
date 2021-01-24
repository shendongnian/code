	DeviceUpdateEvent deviceView1 = null;
	DeviceUpdateEvent deviceView2 = null;
	var subject = new ReplaySubject<IDeviceView>();
	var id1 = Guid.NewGuid();
	var id2 = Guid.NewGuid();
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id1, Voltage = 1 });
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id1, Voltage = 2 });
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id2, Voltage = 100 });
	var service = new DeviceService(subject);
	
	service.GetDeviceStream(id1).Subscribe(x => deviceView1 = x);
	service.GetDeviceStream(id2).Subscribe(x => deviceView2 = x);
	/// I believe there is no need to pause here because the Subscribe method calls above 
	/// block until the events have all been pushed into the subscribers above.
	Assert.AreEqual(deviceView1.View.DeviceId, id1);
	Assert.AreEqual(deviceView2.View.DeviceId, id2);
	Assert.AreEqual(deviceView1.View.Voltage, 2);
	Assert.AreEqual(deviceView2.View.Voltage, 100);
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id2, Voltage = 101 });
	//await Task.Delay(100); /// Not necessary anymore
	Assert.AreEqual(deviceView2.View.Voltage, 101);
