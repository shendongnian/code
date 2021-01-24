    // 1. Run the Write - Part on a Threadpool Thread ...
    private Task WriteRegAsync( float variable , ModbusClient client )
    {
        return Task.Run(() => {
            client.WriteMultipleRegisters(
                         2,  
                         ModbusClient.ConvertFloatToRegisters( variable,
                                                               ModbusClient.RegisterOrder.HighLow)
             );
        });
    }
    
    // 2. Run the Read-Part on a Threadpool Thread
    private Task<string> ReadRegAsync( int address, ModbusClient client )
    {
        return Task.Run( () => {
            return ModbusClient.ConvertRegistersToFloat( 
                                      client.ReadHoldingRegisters(address, 2), 
                                      ModbusClient.RegisterOrder.HighLow)
                               .ToString();
        });
    }
    // "async" makes "await" available for use. Since this is an EventHandler, "async void" is ok. (Usually, you make that "async Task") 
    private async void tmr_Modbus_Com_Tick(object sender, EventArgs e)
    {
        tmr_Modbus_Com.Enabled = false;
        // Write _asynchronously_, your app will stay responsive.
        await WriteRegAsync( (float)variable, modbusClient );
        // then read asynchronously. Again, App will stay responsive.
        textbox1.Text = await ReadRegAsync(384, modbusClient);
        tmr_Modbus_Com.Enabled = true
    }
