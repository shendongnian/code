    foreach (PartialMonitoringObject windowsComputerObject in windowsComputerObjects)
                    {
                        if (windowsComputerObject.InMaintenanceMode)
                        {
                            if (DelayInMinutes == 0)
                            {
                                windowsComputerObject.StopMaintenanceMode(DateTime.UtcNow, Microsoft.EnterpriseManagement.Common.TraversalDepth.Recursive);
                            }
                            else
                            {
                                windowsComputerObject.UpdateMaintenanceMode(DateTime.UtcNow.AddMinutes(DelayInMinutes), MaintenanceModeReason.PlannedOther, null, Microsoft.EnterpriseManagement.Common.TraversalDepth.Recursive);
                            }
                             
                            RetVal = true;
                        }
                    }
`
