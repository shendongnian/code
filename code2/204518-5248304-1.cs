       private void acquire(System.Windows.Forms.Form parent)
        {
            DirectInput dinput = new DirectInput();
            pad = new Joystick(dinput, this.Device.Guid);
            foreach (DeviceObjectInstance doi in pad.GetObjects(ObjectDeviceType.Axis))
            {
                pad.GetObjectPropertiesById((int)doi.ObjectType).SetRange(-5000, 5000);
            }
            pad.Properties.AxisMode = DeviceAxisMode.Absolute;
            pad.SetCooperativeLevel(parent, (CooperativeLevel.Nonexclusive | CooperativeLevel.Background));
            pad.Acquire();
        }
