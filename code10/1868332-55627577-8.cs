        private void SetAsPRX()
        {
            byte configByte;
            nRf24.WriteRegister(IS_nRF24L01p.Common.Registers.RX_ADDR_P1, new byte[] { 0xF0, 0xF0, 0xF, 0x0F, 0x0E1 });
            configByte = 0;
            nRf24.SetRegisterBit(ref configByte, true, 0);
            nRf24.SetRegisterBit(ref configByte, true, 1);
            nRf24.SetRegisterBit(ref configByte, true, 2);
            nRf24.SetRegisterBit(ref configByte, true, 3);
            nRf24.WriteRegister(IS_nRF24L01p.Common.Registers.CONFIG, new byte[] { configByte });
            nRf24.WriteRegister(IS_nRF24L01p.Common.Registers.STATUS, new byte[] { 0xE });
            byte[] StatusBuffer = null;
            nRf24.FlushRXFIFO();
            StatusBuffer = nRf24.ReadRegister(IS_nRF24L01p.Common.Registers.STATUS);
            nRf24.WriteRegister(IS_nRF24L01p.Common.Registers.STATUS, new byte[] { System.Convert.ToByte(StatusBuffer[0] | 0x40) });
            System.Diagnostics.Debug.WriteLine("Finish SetAsPrx()");
        }
