        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();
            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin = null;
                GpioStatus.Text = "There is no GPIO controller on this device.";
                return;
            }
            pin = gpio.OpenPin(LED_PIN);
            pin.ValueChanged += Pin_ValueChanged;
            pin.SetDriveMode(GpioPinDriveMode.Input);
        }
        private void Pin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            if(args.Edge == GpioPinEdge.RisingEdge)
            {
                sender.Write(GpioPinValue.High);
                Task.Delay(500).Wait();
            }
        }
