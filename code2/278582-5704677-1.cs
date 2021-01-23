    private void MakeCarTypeListBox(int carId)
        {
            lstCarType.Items.Clear();
            CarType[] carTypes = CarType.CarTypesByCarNameI(carId);
            for (int i = 0; i < carTypes.Length; i++)
            {
                ListViewItem item = new ListViewItem(carTypes[i].Id.ToString());
                item.SubItems.Add(carTypes[i].CarTypeName);
                item.Tag = carTypes[i].Id;
                lstDetail.Items.Add(item);
            }
        }
