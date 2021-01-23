    using (axRecord = ax.CreateAxaptaRecord("TempTable"))
    {
        var xppDateTime = ax.CallStaticClassMethod("Global", "CLRSystemDateTime2UtcDateTime", DateTime.Now);
        axRecord.set_Field("DateField", xppDateTime);
        axRecord.Insert();
    }
