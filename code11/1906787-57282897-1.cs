    namespace CamTest
    {
        class Camera
        {
            public void funCForBoOut_SelectedIndexChanged()
            {
                ///Declaration
                int num = cboOut.SelectedIndex;
                cmd = 0x101E;
                len = 0x0001;
    
                ///Code
                if (num == 0)
                {
                    val = 0x03;
                }
                else if (num == 1)
                {
                    val = 0x02;
                }
                else if (num == 2)
                {
                    val = 0x01;
                }
                else
                {
                    val = 0x00;
                }
    
                ///Pack
                Packs(len, cmd, val);
            }
    }
