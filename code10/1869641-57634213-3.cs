        /// <summary>
        /// For the given virtual machine, this sample will delete VLAN on existing network adapter 
        /// </summary>
        public void RemoveVLANFromVMNetworkAdapter()
        {
            using (ManagementObject managementService = WmiUtils.GetVirtualMachineManagementService(_dataFields._scope))
            //
            // Find the virtual machine we want to connect.
            //
            using (ManagementObject virtualMachine = WmiUtils.GetVirtualMachine(_dataFields.VmName, _dataFields._scope))
            //
            // Now that we have added a network adapter to the virtual machine we can configure its
            // connection settings.
            //
            using (ManagementObjectCollection findConnections = NetworkUtils.FindConnections(virtualMachine, _dataFields._scope))
            {
                if (findConnections.Count > 0)
                {
                    foreach (ManagementObject connection in findConnections)
                    {
                        // Get network adapter on virtual machine
                        using (ManagementObjectCollection vmSwitches = connection.GetRelated("Msvm_SyntheticEthernetPortSettingData"))
                        {
                            if (vmSwitches.Count > 0)
                            {
                                foreach (ManagementObject vmSwitch in vmSwitches)
                                {
                                    if (vmSwitch["ElementName"].ToString() == _dataFields.NetworkAdapterName)
                                    {
                                        // Get vlan settings data from network adapter
                                        using (ManagementObjectCollection vmSwitcheVLANs = connection.GetRelated("Msvm_EthernetSwitchPortVlanSettingData"))
                                        {
                                            if (vmSwitcheVLANs.Count > 0)
                                            {
                                                // Get first objecz
                                                using (ManagementObject vlanData = WmiUtils.GetFirstObjectFromCollection(vmSwitcheVLANs))
                                                {
                                                    using (ManagementBaseObject inParams = managementService.GetMethodParameters("RemoveFeatureSettings"))
                                                    {
                                                        // Remove it
                                                        inParams["FeatureSettings"] = new string[] { vlanData.Path.Path };
                                                        using (ManagementBaseObject outParams = managementService.InvokeMethod("RemoveFeatureSettings", inParams, null))
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
                    }
                }
            }
        }
