    public class Win32_OnBoardDevice : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Caption,
                        _CreationClassName,
                        _Description,
                        _DeviceType,
                        _Enabled,
                        _HotSwappable,
                        _InstallDate,
                        _Manufacturer,
                        _Model,
                        _Name,
                        _OtherIdentifyingInfo,
                        _PartNumber,
                        _PoweredOn,
                        _Removable,
                        _Replaceable,
                        _SerialNumber,
                        _SKU,
                        _Status,
                        _Tag,
                        _Version
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_ParallelPort : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Availability,
                        _Capabilities_,
                        _CapabilityDescriptions_,
                        _Caption,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserConfig,
                        _CreationClassName,
                        _Description,
                        _DeviceID,
                        _DMASupport,
                        _ErrorCleared,
                        _ErrorDescription,
                        _InstallDate,
                        _LastErrorCode,
                        _MaxNumberControlled,
                        _Name,
                        _OSAutoDiscovered,
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
                
                public class Win32_PhysicalMedia : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Caption,
                        _Description,
                        _InstallDate,
                        _Name,
                        _Status,
                        _CreationClassName,
                        _Manufacturer,
                        _Model,
                        _SKU,
                        _SerialNumber,
                        _Tag,
                        _Version,
                        _PartNumber,
                        _OtherIdentifyingInfo,
                        _PoweredOn,
                        _Removable,
                        _Replaceable,
                        _HotSwappable,
                        _Capacity,
                        _MediaType,
                        _MediaDescription,
                        _WriteProtectOn,
                        _CleanerMedia
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_PhysicalMemory : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _BankLabel,
                        _Capacity,
                        _Caption,
                        _CreationClassName,
                        _DataWidth,
                        _Description,
                        _DeviceLocator,
                        _FormFactor,
                        _HotSwappable,
                        _InstallDate,
                        _InterleaveDataDepth,
                        _InterleavePosition,
                        _Manufacturer,
                        _MemoryType,
                        _Model,
                        _Name,
                        _OtherIdentifyingInfo,
                        _PartNumber,
                        _PositionInRow,
                        _PoweredOn,
                        _Removable,
                        _Replaceable,
                        _SerialNumber,
                        _SKU,
                        _Speed,
                        _Status,
                        _Tag,
                        _TotalWidth,
                        _TypeDetail,
                        _Version
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                
                public class Win32_PortResource : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Alias,
                        _Caption,
                        _CreationClassName,
                        _CSCreationClassName,
                        _CSName,
                        _Description,
                        _EndingAddress,
                        _InstallDate,
                        _Name,
                        _StartingAddress,
                        _Status
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                
                public class Win32_Processor : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _AddressWidth,
                        _Architecture,
                        _Availability,
                        _Caption,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserConfig,
                        _CpuStatus,
                        _CreationClassName,
                        _CurrentClockSpeed,
                        _CurrentVoltage,
                        _DataWidth,
                        _Description,
                        _DeviceID,
                        _ErrorCleared,
                        _ErrorDescription,
                        _ExtClock,
                        _Family,
                        _InstallDate,
                        _L2CacheSize,
                        _L2CacheSpeed,
                        _L3CacheSize,
                        _L3CacheSpeed,
                        _LastErrorCode,
                        _Level,
                        _LoadPercentage,
                        _Manufacturer,
                        _MaxClockSpeed,
                        _Name,
                        _NumberOfCores,
                        _NumberOfLogicalProcessors,
                        _OtherFamilyDescription,
                        _PNPDeviceID,
                        _PowerManagementSupported,
                        _ProcessorId,
                        _ProcessorType,
                        _Revision,
                        _Role,
                        _SocketDesignation,
                        _Status,
                        _StatusInfo,
                        _Stepping,
                        _SystemCreationClassName,
                        _SystemName,
                        _UniqueId,
                        _UpgradeMethod,
                        _Version,
                        _VoltageCaps
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                
                public class Win32_SerialPort : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Availability,
                        _Binary,
                        _Capabilities_,
                        _CapabilityDescriptions_,
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
                        _MaxBaudRate,
                        _MaximumInputBufferSize,
                        _MaximumOutputBufferSize,
                        _MaxNumberControlled,
                        _Name,
                        _OSAutoDiscovered,
                        _PNPDeviceID,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _ProtocolSupported,
                        _ProviderType,
                        _SettableBaudRate,
                        _SettableDataBits,
                        _SettableFlowControl,
                        _SettableParity,
                        _SettableParityCheck,
                        _SettableRLSD,
                        _SettableStopBits,
                        _Status,
                        _StatusInfo,
                        _Supports16BitMode,
                        _SupportsDTRDSR,
                        _SupportsElapsedTimeouts,
                        _SupportsIntTimeouts,
                        _SupportsParityCheck,
                        _SupportsRLSD,
                        _SupportsRTSCTS,
                        _SupportsSpecialCharacters,
                        _SupportsXOnXOff,
                        _SupportsXOnXOffSet,
                        _SystemCreationClassName,
                        _SystemName,
                        _TimeOfLastReset
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                
                public class Win32_SoundDevice : Win32
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
                        _DMABufferSize,
                        _ErrorCleared,
                        _ErrorDescription,
                        _InstallDate,
                        _LastErrorCode,
                        _Manufacturer,
                        _MPU401Address,
                        _Name,
                        _PNPDeviceID,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _ProductName,
                        _Status,
                        _StatusInfo,
                        _SystemCreationClassName,
                        _SystemName
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_SystemEnclosure : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _AudibleAlarm,
                        _BreachDescription,
                        _CableManagementStrategy,
                        _Caption,
                        _ChassisTypes_,
                        _CreationClassName,
                        _CurrentRequiredOrProduced,
                        _Depth,
                        _Description,
                        _HeatGeneration,
                        _Height,
                        _HotSwappable,
                        _InstallDate,
                        _LockPresent,
                        _Manufacturer,
                        _Model,
                        _Name,
                        _NumberOfPowerCords,
                        _OtherIdentifyingInfo,
                        _PartNumber,
                        _PoweredOn,
                        _Removable,
                        _Replaceable,
                        _SecurityBreach,
                        _SecurityStatus,
                        _SerialNumber,
                        _ServiceDescriptions_,
                        _ServicePhilosophy_,
                        _SKU,
                        _SMBIOSAssetTag,
                        _Status,
                        _Tag,
                        _TypeDescriptions_,
                        _Version,
                        _VisibleAlarm,
                        _Weight,
                        _Width
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_TapeDrive : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Availability,
                        _Capabilities_,
                        _CapabilityDescriptions_,
                        _Caption,
                        _Compression,
                        _CompressionMethod,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserConfig,
                        _CreationClassName,
                        _DefaultBlockSize,
                        _Description,
                        _DeviceID,
                        _ECC,
                        _EOTWarningZoneSize,
                        _ErrorCleared,
                        _ErrorDescription,
                        _ErrorMethodology,
                        _FeaturesHigh,
                        _FeaturesLow,
                        _Id,
                        _InstallDate,
                        _LastErrorCode,
                        _Manufacturer,
                        _MaxBlockSize,
                        _MaxMediaSize,
                        _MaxPartitionCount,
                        _MediaType,
                        _MinBlockSize,
                        _Name,
                        _NeedsCleaning,
                        _NumberOfMediaSupported,
                        _Padding,
                        _PNPDeviceID,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _ReportSetMarks,
                        _Status,
                        _StatusInfo,
                        _SystemCreationClassName,
                        _SystemName
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_TemperatureProbe : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Accuracy,
                        _Availability,
                        _Caption,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserConfig,
                        _CreationClassName,
                        _CurrentReading,
                        _Description,
                        _DeviceID,
                        _ErrorCleared,
                        _ErrorDescription,
                        _InstallDate,
                        _IsLinear,
                        _LastErrorCode,
                        _LowerThresholdCritical,
                        _LowerThresholdFatal,
                        _LowerThresholdNonCritical,
                        _MaxReadable,
                        _MinReadable,
                        _Name,
                        _NominalReading,
                        _NormalMax,
                        _NormalMin,
                        _PNPDeviceID,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _Resolution,
                        _Status,
                        _StatusInfo,
                        _SystemCreationClassName,
                        _SystemName,
                        _Tolerance,
                        _UpperThresholdCritical,
                        _UpperThresholdFatal,
                        _UpperThresholdNonCritical
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_UninterruptiblePowerSupply : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _ActiveInputVoltage,
                        _Availability,
                        _BatteryInstalled,
                        _CanTurnOffRemotely,
                        _Caption,
                        _CommandFile,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserConfig,
                        _CreationClassName,
                        _Description,
                        _DeviceID,
                        _ErrorCleared,
                        _ErrorDescription,
                        _EstimatedChargeRemaining,
                        _EstimatedRunTime,
                        _FirstMessageDelay,
                        _InstallDate,
                        _IsSwitchingSupply,
                        _LastErrorCode,
                        _LowBatterySignal,
                        _MessageInterval,
                        _Name,
                        _PNPDeviceID,
                        _PowerFailSignal,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _Range1InputFrequencyHigh,
                        _Range1InputFrequencyLow,
                        _Range1InputVoltageHigh,
                        _Range1InputVoltageLow,
                        _Range2InputFrequencyHigh,
                        _Range2InputFrequencyLow,
                        _Range2InputVoltageHigh,
                        _Range2InputVoltageLow,
                        _RemainingCapacityStatus,
                        _Status,
                        _StatusInfo,
                        _SystemCreationClassName,
                        _SystemName,
                        _TimeOnBackup,
                        _TotalOutputPower,
                        _TypeOfRangeSwitching,
                        _UPSPort
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_USBController : Win32
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
                public class Win32_USBHub : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Availability,
                        _Caption,
                        _ClassCode,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserCode,
                        _CreationClassName,
                        _CurrentAlternativeSettings,
                        _CurrentConfigValue,
                        _Description,
                        _DeviceID,
                        _ErrorCleared,
                        _ErrorDescription,
                        _GangSwitched,
                        _InstallDate,
                        _LastErrorCode,
                        _Name,
                        _NumberOfConfigs,
                        _NumberOfPorts,
                        _PNPDeviceID,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _ProtocolCode,
                        _Status,
                        _StatusInfo,
                        _SubclassCode,
                        _SystemCreationClassName,
                        _SystemName,
                        _USBVersion
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_VideoController : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _AcceleratorCapabilities_,
                        _AdapterCompatibility,
                        _AdapterDACType,
                        _AdapterRAM,
                        _Availability,
                        _CapabilityDescriptions_,
                        _Caption,
                        _ColorTableEntries,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserConfig,
                        _CreationClassName,
                        _CurrentBitsPerPixel,
                        _CurrentHorizontalResolution,
                        _CurrentNumberOfColors,
                        _CurrentNumberOfColumns,
                        _CurrentNumberOfRows,
                        _CurrentRefreshRate,
                        _CurrentScanMode,
                        _CurrentVerticalResolution,
                        _Description,
                        _DeviceID,
                        _DeviceSpecificPens,
                        _DitherType,
                        _DriverDate,
                        _DriverVersion,
                        _ErrorCleared,
                        _ErrorDescription,
                        _ICMIntent,
                        _ICMMethod,
                        _InfFilename,
                        _InfSection,
                        _InstallDate,
                        _InstalledDisplayDrivers,
                        _LastErrorCode,
                        _MaxMemorySupported,
                        _MaxNumberControlled,
                        _MaxRefreshRate,
                        _MinRefreshRate,
                        _Monochrome,
                        _Name,
                        _NumberOfColorPlanes,
                        _NumberOfVideoPages,
                        _PNPDeviceID,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _ProtocolSupported,
                        _ReservedSystemPaletteEntries,
                        _SpecificationVersion,
                        _Status,
                        _StatusInfo,
                        _SystemCreationClassName,
                        _SystemName,
                        _SystemPaletteEntries,
                        _TimeOfLastReset,
                        _VideoArchitecture,
                        _VideoMemoryType,
                        _VideoMode,
                        _VideoModeDescription,
                        _VideoProcessor
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
                public class Win32_VoltageProbe : Win32
                {
                    public string Name { get { return this.GetType().ToString().Split('+').Last().Split('.').Last(); } } public Property property { get; set; }
                    public enum Property
                    {
                        _Accuracy,
                        _Availability,
                        _Caption,
                        _ConfigManagerErrorCode,
                        _ConfigManagerUserConfig,
                        _CreationClassName,
                        _CurrentReading,
                        _Description,
                        _DeviceID,
                        _ErrorCleared,
                        _ErrorDescription,
                        _InstallDate,
                        _IsLinear,
                        _LastErrorCode,
                        _LowerThresholdCritical,
                        _LowerThresholdFatal,
                        _LowerThresholdNonCritical,
                        _MaxReadable,
                        _MinReadable,
                        _Name,
                        _NominalReading,
                        _NormalMax,
                        _NormalMin,
                        _PNPDeviceID,
                        _PowerManagementCapabilities_,
                        _PowerManagementSupported,
                        _Resolution,
                        _Status,
                        _StatusInfo,
                        _SystemCreationClassName,
                        _SystemName,
                        _Tolerance,
                        _UpperThresholdCritical,
                        _UpperThresholdFatal,
                        _UpperThresholdNonCritical
                    }
                    public string GetInfo { get { return GetWMI(this); } }
                }
