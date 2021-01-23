    private void UpdateBatteryIcon()
    {
        var batteryLevel = SystemState.PowerBatteryStrength;
        var isOnCharge = IsOnCharge(SystemState.PowerBatteryState);
        pictBattery.Image = GetBatteryIcon(batteryLevel, isOnCharge);
    }
    private static Bitmap GetBatteryIcon(BatteryLevel batteryState, bool isCharging)
    {
        if (isCharging)
        {
            return Icons.BatteryChargingHorizontal;
        }
        if (batteryState == BatteryLevel.VeryLow)
        {
            return Icons.BatteryVeryLowHorizontal;
        }
        if (batteryState == BatteryLevel.Low)
        {
            return Icons.BatteryLowHorizontal;
        }
        if (batteryState == BatteryLevel.Medium)
        {
            return Icons.BatteryMediumHorizontal;
        }
        if (batteryState == BatteryLevel.High)
        {
            return Icons.BatteryHighHorizontal;
        }
        return Icons.BatteryFullHorizontal;
    }
