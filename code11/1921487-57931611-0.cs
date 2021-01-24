    public void LoadNLDNSensors()
        {
            DirectoryInfo d = new DirectoryInfo(filepath);
            string[] files = Directory.GetFiles(filepath);
            if (files.Length == 0)
            {
                MessageBox.Show("Couldn't find sensor files!", "Failure",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach(var file in d.GetFiles("*.sensor"))
            {
                IFormatter formatter = new BinaryFormatter();
                NLDNSensor __newSensor = new NLDNSensor();
                __newSensor = __newSensor.LoadSensorFromFile(file);
                buttons.Add(__newSensor.Brief, __newSensor);
                //flowLayoutPanelSensors.Controls.Add(bu);
            }
            foreach (string str in buttons.Keys)
            {
                Button b = new Button();
                b.BackColor = Color.Pink;
                switch (buttons[str].SensorState)
                {
                    case -1:
                        b.BackColor = Color.Red;
                        break;
                    case 0:
                        b.BackColor = Color.Aqua;
                        break;
                    case 1:
                        b.BackColor = Color.Yellow;
                        break;
                    default:
                        b.BackColor = Color.White;
                        break;
                }
                b.Height = 40;
                b.Width = 40;
                b.Text = buttons[str].Brief;
                b.Visible = true;
                flowLayoutPanelSensors.Controls.Add(b);
            }
            return;
        }
