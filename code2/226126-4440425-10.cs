        foreach (string groupName in _dicPortStatus.Keys)
        {
            if (!cmbGroups.Items.Contains(groupName))
            {
                cmbGroups.Items.Add(new GroupInfo(){ GroupName = groupName, IP = <Write Code to get IP>);
                cmbGroups.SelectedItem = groupName;
            }
        }
