    using System;
    using System.Linq;
    using System.Management;
    
    namespace MySystemInfo
    {
    
            public abstract class Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } }
    
                protected static string GetWMI(Win32 win32)
                {
    
                    string p = win32.GetType().GetProperty("property").GetValue(win32, null).ToString().Substring(1);
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + win32.Name);
                    ManagementObjectCollection managementObjects = searcher.Get();
                    try
                    {
                        foreach (ManagementObject obj in managementObjects)
                        {
                            if (obj[p] != null)
                            {
                                var temp = obj[p];
                                return temp.ToString();
                            }
                        }
                    }
                    catch { }
    
                    return String.Empty;
                }
            }
    
            public class Win32_BaseBoard : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Caption,
                    _CreationClassName,
                    _Depth,
                    _Description,
                    _Height,
                    _HostingBoard,
                    _HotSwappable,
                    _InstallDate,
                    _Manufacturer,
                    _Model,
                    _Name,
                    _OtherIdentifyingInfo,
                    _PartNumber,
                    _PoweredOn,
                    _Product,
                    _Removable,
                    _Replaceable,
                    _RequirementsDescription,
                    _RequiresDaughterBoard,
                    _SerialNumber,
                    _SKU,
                    _SlotLayout,
                    _SpecialRequirements,
                    _Status,
                    _Tag,
                    _Version,
                    _Weight,
                    _Width
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_Battery : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _BatteryRechargeTime,
                    _BatteryStatus,
                    _Caption,
                    _Chemistry,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _Description,
                    _DesignCapacity,
                    _DesignVoltage,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _EstimatedChargeRemaining,
                    _EstimatedRunTime,
                    _ExpectedBatteryLife,
                    _ExpectedLife,
                    _FullChargeCapacity,
                    _InstallDate,
                    _LastErrorCode,
                    _MaxRechargeTime,
                    _Name,
                    _PNPDeviceID,
                    _PowerManagementSupported,
                    _SmartBatteryVersion,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName,
                    _TimeOnBattery,
                    _TimeToFullCharge
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_BIOS : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _BuildNumber,
                    _Caption,
                    _CodeSet,
                    _CurrentLanguage,
                    _Description,
                    _IdentificationCode,
                    _InstallableLanguages,
                    _InstallDate,
                    _LanguageEdition,
                    _Manufacturer,
                    _Name,
                    _OtherTargetOS,
                    _PrimaryBIOS,
                    _ReleaseDate,
                    _SerialNumber,
                    _SMBIOSBIOSVersion,
                    _SMBIOSMajorVersion,
                    _SMBIOSMinorVersion,
                    _SMBIOSPresent,
                    _SoftwareElementID,
                    _SoftwareElementState,
                    _Status,
                    _TargetOperatingSystem,
                    _Version
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_Bus : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _BusNum,
                    _BusType,
                    _Caption,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _Description,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _InstallDate,
                    _LastErrorCode,
                    _Name,
                    _PNPDeviceID,
                    _PowerManagementSupported,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_CDROMDrive : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _Caption,
                    _CompressionMethod,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _DefaultBlockSize,
                    _Description,
                    _DeviceID,
                    _Drive,
                    _DriveIntegrity,
                    _ErrorCleared,
                    _ErrorDescription,
                    _ErrorMethodology,
                    _FileSystemFlags,
                    _FileSystemFlagsEx,
                    _InstallDate,
                    _LastErrorCode,
                    _Manufacturer,
                    _MaxBlockSize,
                    _MaximumComponentLength,
                    _MaxMediaSize,
                    _MediaLoaded,
                    _MediaType,
                    _MfrAssignedRevisionLevel,
                    _MinBlockSize,
                    _Name,
                    _NeedsCleaning,
                    _NumberOfMediaSupported,
                    _PNPDeviceID,
                    _PowerManagementSupported,
                    _RevisionLevel,
                    _SCSIBus,
                    _SCSILogicalUnit,
                    _SCSIPort,
                    _SCSITargetId,
                    _SerialNumber,
                    _Size,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName,
                    _TransferRate,
                    _VolumeName,
                    _VolumeSerialNumber
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_DiskDrive : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _BytesPerSector,
                    _Capabilities_,
                    _CapabilityDescriptions_,
                    _Caption,
                    _CompressionMethod,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _DefaultBlockSize,
                    _Description,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _ErrorMethodology,
                    _FirmwareRevision,
                    _Index,
                    _InstallDate,
                    _InterfaceType,
                    _LastErrorCode,
                    _Manufacturer,
                    _MaxBlockSize,
                    _MaxMediaSize,
                    _MediaLoaded,
                    _MediaType,
                    _MinBlockSize,
                    _Model,
                    _Name,
                    _NeedsCleaning,
                    _NumberOfMediaSupported,
                    _Partitions,
                    _PNPDeviceID,
                    _PowerManagementCapabilities_,
                    _PowerManagementSupported,
                    _SCSIBus,
                    _SCSILogicalUnit,
                    _SCSIPort,
                    _SCSITargetId,
                    _SectorsPerTrack,
                    _SerialNumber,
                    _Signature,
                    _Size,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName,
                    _TotalCylinders,
                    _TotalHeads,
                    _TotalSectors,
                    _TotalTracks,
                    _TracksPerCylinder
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_DMAChannel : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _16AddressSize,
                    _16Availability,
                    _BurstMode,
                    _16ByteMode,
                    _Caption,
                    _16ChannelTiming,
                    _CreationClassName,
                    _CSCreationClassName,
                    _CSName,
                    _Description,
                    _32DMAChannel,
                    _InstallDate,
                    _32MaxTransferSize,
                    _Name,
                    _32Port,
                    _Status,
                    _16TransferWidths_,
                    _16TypeCTiming,
                    _16WordMode
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_Fan : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _ActiveCooling,
                    _Availability,
                    _Caption,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _Description,
                    _DesiredSpeed,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _InstallDate,
                    _LastErrorCode,
                    _Name,
                    _PNPDeviceID,
                    _PowerManagementCapabilities_,
                    _PowerManagementSupported,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName,
                    _VariableSpeed
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_FloppyController : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _Caption,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _Description,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _InstallDate,
                    _LastErrorCode,
                    _Manufacturer,
                    _MaxNumberControlled,
                    _Name,
                    _PNPDeviceID,
                    _PowerManagementSupported,
                    _ProtocolSupported,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName,
                    _TimeOfLastReset
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_FloppyDrive : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _Caption,
                    _CompressionMethod,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _DefaultBlockSize,
                    _Description,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _ErrorMethodology,
                    _InstallDate,
                    _LastErrorCode,
                    _Manufacturer,
                    _MaxBlockSize,
                    _MaxMediaSize,
                    _MinBlockSize,
                    _Name,
                    _NeedsCleaning,
                    _NumberOfMediaSupported,
                    _PNPDeviceID,
                    _PowerManagementCapabilities_,
                    _PowerManagementSupported,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_IDEController : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _Caption,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _Description,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _InstallDate,
                    _LastErrorCode,
                    _Manufacturer,
                    _MaxNumberControlled,
                    _Name,
                    _PNPDeviceID,
                    _PowerManagementCapabilities_,
                    _PowerManagementSupported,
                    _ProtocolSupported,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName,
                    _TimeOfLastReset
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_IRQResource : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _Caption,
                    _CreationClassName,
                    _CSCreationClassName,
                    _CSName,
                    _Description,
                    _Hardware,
                    _InstallDate,
                    _IRQNumber,
                    _Name,
                    _Shareable,
                    _Status,
                    _TriggerLevel,
                    _TriggerType,
                    _Vector
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_Keyboard : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Availability,
                    _Caption,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _Description,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _InstallDate,
                    _IsLocked,
                    _LastErrorCode,
                    _Layout,
                    _Name,
                    _NumberOfFunctionKeys,
                    _Password,
                    _PNPDeviceID,
                    _PowerManagementSupported,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_MemoryDevice : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _Access,
                    _AdditionalErrorData_,
                    _Availability,
                    _BlockSize,
                    _Caption,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CorrectableError,
                    _CreationClassName,
                    _Description,
                    _DeviceID,
                    _EndingAddress,
                    _ErrorAccess,
                    _ErrorAddress,
                    _ErrorCleared,
                    _ErrorDataOrder,
                    _ErrorDescription,
                    _ErrorGranularity,
                    _ErrorInfo,
                    _ErrorMethodology,
                    _ErrorResolution,
                    _ErrorTime,
                    _ErrorTransferSize,
                    _InstallDate,
                    _LastErrorCode,
                    _Name,
                    _NumberOfBlocks,
                    _OtherErrorDescription,
                    _PNPDeviceID,
                    _PowerManagementCapabilities_,
                    _PowerManagementSupported,
                    _Purpose,
                    _StartingAddress,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemLevelAddress,
                    _SystemName
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_NetworkAdapter : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _AdapterType,
                    _AdapterTypeID,
                    _AutoSense,
                    _Availability,
                    _Caption,
                    _ConfigManagerErrorCode,
                    _ConfigManagerUserConfig,
                    _CreationClassName,
                    _Description,
                    _DeviceID,
                    _ErrorCleared,
                    _ErrorDescription,
                    _GUID,
                    _Index,
                    _InstallDate,
                    _Installed,
                    _InterfaceIndex,
                    _LastErrorCode,
                    _MACAddress,
                    _Manufacturer,
                    _MaxNumberControlled,
                    _MaxSpeed,
                    _Name,
                    _NetConnectionID,
                    _NetConnectionStatus,
                    _NetEnabled,
                    _NetworkAddresses_,
                    _PermanentAddress,
                    _PhysicalAdapter,
                    _PNPDeviceID,
                    _PowerManagementCapabilities_,
                    _PowerManagementSupported,
                    _ProductName,
                    _ServiceName,
                    _Speed,
                    _Status,
                    _StatusInfo,
                    _SystemCreationClassName,
                    _SystemName,
                    _TimeOfLastReset
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            public class Win32_NetworkAdapterConfiguration : Win32
            {
                public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                public enum Property
                {
                    _ArpAlwaysSourceRoute,
                    _ArpUseEtherSNAP,
                    _Caption,
                    _DatabasePath,
                    _DeadGWDetectEnabled,
                    _DefaultIPGateway_,
                    _DefaultTOS,
                    _DefaultTTL,
                    _Description,
                    _DHCPEnabled,
                    _DHCPLeaseExpires,
                    _DHCPLeaseObtained,
                    _DHCPServer,
                    _DNSDomain,
                    _DNSDomainSuffixSearchOrder_,
                    _DNSEnabledForWINSResolution,
                    _DNSHostName,
                    _DNSServerSearchOrder_,
                    _DomainDNSRegistrationEnabled,
                    _ForwardBufferMemory,
                    _FullDNSRegistrationEnabled,
                    _GatewayCostMetric_,
                    _IGMPLevel,
                    _Index,
                    _InterfaceIndex,
                    _IPAddress_,
                    _IPConnectionMetric,
                    _IPEnabled,
                    _IPFilterSecurityEnabled,
                    _IPPortSecurityEnabled,
                    _IPSecPermitIPProtocols_,
                    _IPSecPermitTCPPorts_,
                    _IPSecPermitUDPPorts_,
                    _IPSubnet_,
                    _IPUseZeroBroadcast,
                    _IPXAddress,
                    _IPXEnabled,
                    _IPXFrameType_,
                    _IPXMediaType,
                    _IPXNetworkNumber_,
                    _IPXVirtualNetNumber,
                    _KeepAliveInterval,
                    _KeepAliveTime,
                    _MACAddress,
                    _MTU,
                    _NumForwardPackets,
                    _PMTUBHDetectEnabled,
                    _PMTUDiscoveryEnabled,
                    _ServiceName,
                    _SettingID,
                    _TcpipNetbiosOptions,
                    _TcpMaxConnectRetransmissions,
                    _TcpMaxDataRetransmissions,
                    _TcpNumConnections,
                    _TcpUseRFC1122UrgentPointer,
                    _TcpWindowSize,
                    _WINSEnableLMHostsLookup,
                    _WINSHostLookupFile,
                    _WINSPrimaryServer,
                    _WINSScopeID,
                    _WINSSecondaryServer
                }
                public string GetInfo { get { return GetWMI(this); } }
            }
            
    
    
    }
