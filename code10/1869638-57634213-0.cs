        /// <summary>
        /// For the given virtual machine, this sample adds a new Network Adapter device and 
        /// connects it to the specified switch. Note that in order to add a new Network Adapter 
        /// device to the virtual machine, the virtual machine must be in the power off state.
        /// Also note that the maximum number of Network Adapter devices that may be configured
        /// on a virtual machine is 8.
        /// </summary>
        public void ConnectVmToSwitch()
        {
            using (ManagementObject managementService = WmiUtils.GetVirtualMachineManagementService(_dataFields._scope))
            //
            // Find the Ethernet switch we want to connect to.
            //
            using (ManagementObject ethernetSwitch = NetworkUtils.FindEthernetSwitch(_dataFields.SwitchName, _dataFields._scope))
            //
            // Find the virtual machine we want to connect.
            //
            using (ManagementObject virtualMachine = WmiUtils.GetVirtualMachine(_dataFields.VmName, _dataFields._scope))
            //
            // Get the virtual machine's settings object which is used to make configuration changes.
            //
            using (ManagementObject virtualMachineSettings = WmiUtils.GetVirtualMachineSettings(virtualMachine))
            //
            // Add a new synthetic Network Adapter device to the virtual machine.
            //
            using (ManagementObject syntheticAdapter = NetworkUtils.AddSyntheticAdapter(virtualMachine, _dataFields._scope))
            //
            // Now that we have added a network adapter to the virtual machine we can configure its
            // connection settings.
            //
            using (ManagementObject connectionSettingsToAdd = NetworkUtils.GetDefaultEthernetPortAllocationSettingData(_dataFields._scope))
            {
                connectionSettingsToAdd["Parent"] = syntheticAdapter.Path.Path;
                connectionSettingsToAdd["HostResource"] = new string[] { ethernetSwitch.Path.Path };
                //
                // Now add the connection settings.
                //
                using (ManagementBaseObject addConnectionInParams = managementService.GetMethodParameters("AddResourceSettings"))
                {
                    addConnectionInParams["AffectedConfiguration"] = virtualMachineSettings.Path.Path;
                    addConnectionInParams["ResourceSettings"] = new string[] { connectionSettingsToAdd.GetText(TextFormat.WmiDtd20) };
                    using (ManagementBaseObject addConnectionOutParams = managementService.InvokeMethod("AddResourceSettings", addConnectionInParams, null))
                    {
                        WmiUtils.ValidateOutput(addConnectionOutParams, _dataFields._scope);
                        if (_dataFields.VlanID > 0)
                        {
                            string[] syntheticAdapterResult = (string[])addConnectionOutParams["ResultingResourceSettings"]; // Msvm_EthernetPortAllocationSettingData return object
                            string syntheticAdapterPath = syntheticAdapterResult[0]; // Msvm_EthernetPortAllocationSettingData path
                            using (ManagementClass vlanSettingsData = new ManagementClass("Msvm_EthernetSwitchPortVlanSettingData"))
                            {
                                vlanSettingsData.Scope = _dataFields._scope;
                                using (ManagementObject vlanData = vlanSettingsData.CreateInstance())
                                {
                                    vlanData["AccessVlanId"] = _dataFields.VlanID;
                                    vlanData["OperationMode"] = 1;
                                    // Modify the VM settings.
                                    using (ManagementBaseObject inParams = managementService.GetMethodParameters("AddFeatureSettings"))
                                    {
                                        inParams["AffectedConfiguration"] = syntheticAdapterPath;
                                        inParams["FeatureSettings"] = new string[] { vlanData.GetText(TextFormat.CimDtd20) };
                                        using (ManagementBaseObject outParams = managementService.InvokeMethod("AddFeatureSettings", inParams, null))
                                        {
                                            WmiUtils.ValidateOutput(outParams, _dataFields._scope);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
