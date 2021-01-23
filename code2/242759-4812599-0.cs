        public void VehicleConverter(object obj)
        {
            Type t = obj.GetType().GetGenericArguments()[0].GetType();
            IList lstVec = ((IList)obj);
            foreach (var k in lstVec)
            {
                PropertyInfo[] p = k.GetType().GetProperties();
                foreach (PropertyInfo pi in p)
                    if (pi.Name == "VechicleId")
                        MessageBox.Show(Convert.ToString(pi.GetValue(k, null)));
            }
        }
