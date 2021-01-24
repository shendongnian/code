        private async Task LEDLights(int Device)
        {
            Flag = false;
            if (Device == 1)
            {
                while (Flag == false)
                {
                    //Change LED Colors
                    ChangeLED(Red);
                    await Task.Delay(1000);
                    ChangeLED(Blue);
                    await Task.Delay(1000);
                    ChangeLED(Green);
                    await Task.Delay(1000);
                }
            }
            else
            {
            }
            Flag = false;
        }
        //called with "await LEDLights(1);"
