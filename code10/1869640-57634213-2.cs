        /// <summary>
        /// Gets any virtual machine's management object
        /// </summary>
        /// <param name="managementObject">Any management object</param>
        /// <returns>Any virtual machine's management object.</returns>
        public static ManagementObject
        GetVirtualMachineManagementObject(ManagementObject managementObject, string className)
        {
            using (ManagementObjectCollection settingsCollection = managementObject.GetRelated(className))
            {
                ManagementObject virtualMachineSettings = GetFirstObjectFromCollection(settingsCollection);
                return virtualMachineSettings;
            }
        }
        /// <summary>
        /// For the given virtual machine, this sample will add / modfiy VLAN on existing network adapter
        /// </summary>
        public void SetVLANToVMNetworkAdapter()
        {
            ManagementObject syntheticAdapter = null;
            bool vlanAlreadySet = false;
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
                        using (ManagementObjectCollection vmSwitches = connection.GetRelated("Msvm_SyntheticEthernetPortSettingData"))
                        {
                            if (vmSwitches.Count > 0)
                            {
                                foreach (ManagementObject vmSwitch in vmSwitches)
                                {
                                    if (vmSwitch["ElementName"].ToString() == _dataFields.NetworkAdapterName)
                                    {
                                        //
                                        // Got adapter on VM, lock it to connection object since we need connection path
                                        // for vlan modifications
                                        //
                                        syntheticAdapter = connection;
                                        //
                                        // Got VLAN defiinition based on connection lock for vlan modifications
                                        //
                                        using (ManagementObjectCollection vmSwitcheVLANs = syntheticAdapter.GetRelated("Msvm_EthernetSwitchPortVlanSettingData"))
                                        {
                                            if (vmSwitcheVLANs.Count > 0)
                                                vlanAlreadySet = true;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (syntheticAdapter != null && _dataFields.VlanID > 0)
                {
                    string syntheticAdapterPath = syntheticAdapter.Path.Path;
                    if (vlanAlreadySet)
                    {
                        // VLAN is already set on adapter, change operation
                        // Modify the VM settings.
                        using (ManagementObject vlanData = WmiUtils.GetVirtualMachineManagementObject(syntheticAdapter, "Msvm_EthernetSwitchPortVlanSettingData"))
                        {
                            vlanData["AccessVlanId"] = _dataFields.VlanID;
                            vlanData["OperationMode"] = (uint)_dataFields.VLANOperationalModes;
                            using (ManagementBaseObject inParams = managementService.GetMethodParameters("ModifyFeatureSettings"))
                            {
                                inParams["FeatureSettings"] = new string[] { vlanData.GetText(TextFormat.CimDtd20) };
                                using (ManagementBaseObject outParams = managementService.InvokeMethod("ModifyFeatureSettings", inParams, null))
                                {
                                    WmiUtils.ValidateOutput(outParams, _dataFields._scope);
                                }
                            }
                        }
                    }
                    else
                    {
                        using (ManagementClass vlanSettingsData = new ManagementClass("Msvm_EthernetSwitchPortVlanSettingData"))
                        {
                            vlanSettingsData.Scope = _dataFields._scope;
                            using (ManagementObject vlanData = vlanSettingsData.CreateInstance())
                            {
                                vlanData["AccessVlanId"] = _dataFields.VlanID;
                                vlanData["OperationMode"] = (uint)_dataFields.VLANOperationalModes;
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
