    private void btnSendData_Click(object sender, EventArgs e)
    {
        if (serialPort1.IsOpen)
        {
            //dataOUT = tBoxDataOut.Text;
            int intVal = Int32.Parse(tBoxDataOut.Text);
            dataOUT = intVal.ToString("X");
            if (sendWith == "WriteLine")
            {
                serialPort1.WriteLine(dataOUT);
            }
            else if (sendWith == "Write")
            {
                serialPort1.Write(dataOUT);
            }
        }
    }
