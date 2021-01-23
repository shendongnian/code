        public virtual IList<GamepadDevice> Available()
        {
            IList<GamepadDevice> result = new List<GamepadDevice>();
            DirectInput dinput = new DirectInput();
            foreach (DeviceInstance di in dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                GamepadDevice dev = new GamepadDevice();
                dev.Guid = di.InstanceGuid;
                dev.Name = di.InstanceName;
                result.Add(dev);
            }
            return result;
        }
