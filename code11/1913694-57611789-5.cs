	DeviceUpdateEvent deviceView1 = null;
	DeviceUpdateEvent deviceView2 = null;
	DeviceUpdateEvent deviceView3 = null;
	var subject = new ReplaySubject<IDeviceView>();
	var id1 = Guid.NewGuid();
	var id2 = Guid.NewGuid();
	var id3 = Guid.NewGuid();
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id1, Voltage = 1 });
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id1, Voltage = 2 });
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id2, Voltage = 100 });
	var service = new DeviceService(subject);
	
	service.GetDeviceStream(id1).Subscribe(x => deviceView1 = x);
	service.GetDeviceStream(id2).Subscribe(x => deviceView2 = x);
	service.GetDeviceStream(id3).Subscribe(x => deviceView3 = x);
	/// I believe there is no need to pause here because the Subscribe method calls above 
	/// block until the events have all been pushed into the subscribers above.
	Assert.AreEqual(deviceView1.View.DeviceId, id1);
	Assert.AreEqual(deviceView2.View.DeviceId, id2);
	Assert.AreEqual(deviceView1.View.Voltage, 2);
	Assert.AreEqual(deviceView2.View.Voltage, 100);
	Assert.IsNull(deviceView3);
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id2, Voltage = 101 });
	Assert.AreEqual(deviceView2.View.Voltage, 101);
	subject.OnNext(new DeviceVoltagesUpdateView { DeviceId = id3, Voltage = 101 });
	Assert.AreEqual(deviceView3.View.DeviceId, id3);
	Assert.AreEqual(deviceView3.View.Voltage, 101);
