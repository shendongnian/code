        static DateTime lastMotorPoll;
        const TimeSpan CACHE_PERIOD = new TimeSpan(0, 0, 0, 0, 250);
        private object cachedCheckMotorsDataLock = new object();
        private void CachedCheckMotorsData()
        {
            lock (cachedCheckMotorsDataLock)  //Could refactor this to perform a try enter which returns quickly if required
            {
                //If the last time the data was polled is older than the cache period, poll
                if (lastMotorPoll.Add(CACHE_PERIOD) < DateTime.Now)
                {
                    pollMotorsData();
                    lastMotorPoll = DateTime.Now;
                }
                else //Data is fresh so don't poll
                {
                    return;
                }
            }       
        }
        private void pollMotorsData()
        {
            // Execute single poll with "foreground" handshaking 
            DateTime start = DateTime.Now;
            byte retryCount = 0;
            // Pick old data atomically to detect change
            uint motorsDataTimeStampPrev = this.MotorsDataTimeStamp;
            bool changeDetected = false;
            try
            {
                do
                {
                    // Handshake signal to DPRAM write process on controller side that host PC is reading
                    this.controller.deltaTauTcpClient.Pmac_SetBit(OFFSET_0x006A_BIT15_FOREGROUND_READ, 15, true);
                    try
                    {
                        bool canReadMotors = false;
                        byte[] canReadFrozenDataFlag = new byte[2];
                        do
                        {
                            this.controller.deltaTauTcpClient.Pmac_GetMem(OFFSET_0x006E_BIT15_FOREGROUND_DONE, canReadFrozenDataFlag);
                            canReadMotors = (canReadFrozenDataFlag[1] & 0x80) == 0x80;
                            if (canReadMotors) break;
                            retryCount++;
                            Thread.Sleep(1);
                        } while (retryCount < 10);
                        if (!canReadMotors)
                        {
                            throw new DeltaTauControllerException(this.controller, "Timeout waiting on DPRAM Foreground Handshaking Bit");
                        }
                        // Obtain fresh content of DPRAM
                        this.controller.deltaTauTcpClient.Pmac_GetMem(OFFSET_0x006A_394BYTES_8MOTORS_DATA, this.motorsData);
                        this.motorsDataBorn = DateTime.Now;
                    }
                    finally
                    {
                        // Handshake signal to DPRAM write process on controller side that host PC has finished reading
                        this.controller.deltaTauTcpClient.Pmac_SetBit(OFFSET_0x006A_BIT15_FOREGROUND_READ, 15, false);
                    }
                    // Check live change in a separate atom
                    changeDetected = this.MotorsDataTimeStamp != motorsDataTimeStampPrev;
                } while ((!changeDetected) && ((DateTime.Now - start).TotalMilliseconds < 255));
                
                // Assert that result is live
                if (!changeDetected)
                {
                    throw new DeltaTauControllerException(this.controller, "DPRAM Background Data timestamp is not updated. DPRAM forground handshaking failed.");
                }
            }
        }
