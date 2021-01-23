            foreach (ManagementObject ManObj in ManObjReturn)
            {
                //int s = ManObj.Properties.Count;
                //foreach (PropertyData d in ManObj.Properties)
                //{
                //    MessageBox.Show(d.Name);
                //}
                MessageBox.Show(ManObj["DeviceID"].ToString());
                MessageBox.Show(ManObj["PNPDeviceID"].ToString());
                   MessageBox.Show(ManObj["Name"].ToString());
                   MessageBox.Show(ManObj["Caption"].ToString());
                   MessageBox.Show(ManObj["Description"].ToString());
                   MessageBox.Show(ManObj["ProviderType"].ToString());
                   MessageBox.Show(ManObj["Status"].ToString());
            
            }
