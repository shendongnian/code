        private async void InitAsync()
        {
            Logger.Log(this, "Init");
            // Setup PWM controller.
            if (LightningProvider.IsLightningEnabled)
            {
                var pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
                if (pwmControllers == null || pwmControllers.Count < 2)
                {
                    throw new OperationCanceledException("Operation canceled due missing GPIO controller");
                }
                pwmController = pwmControllers[1];
                pwmController.SetDesiredFrequency(50);
                // Setup buzzer
                buzzerPin = pwmController.OpenPin(13);
                buzzerPin.SetActiveDutyCyclePercentage(0.05);
                buzzerPin.Start();
            }
        }
