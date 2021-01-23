    public class CPUUtilizationTests
    {
    
    	[Test]
    	public void TestPercentProcessorTime()
    	{
    		Assert.That(PercentProcessorTime("Idle"), Is.Not.GreaterThan(100.0));
    	}
    
    	public float PercentProcessorTime(string processName)
    	{
    		var mos = new ManagementObjectSearcher("SELECT * FROM Win32_PerfRawData_PerfProc_Process");
    		var run1 = mos.Get().Cast<ManagementObject>().ToDictionary(mo => mo.Properties["Name"].Value, mo => mo);
    		System.Threading.Thread.Sleep(1000); // can be an arbitrary number
    		var run2 = mos.Get().Cast<ManagementObject>().ToDictionary(mo => mo.Properties["Name"].Value, mo => mo);
    
    		if (!run2.ContainsKey(processName)) throw new Exception(string.Format("Process not found: {0}", processName));
    
    		string percentageProcessorTime = "PercentProcessorTime";
    		string total = "_Total";
    
    		ulong percentageDiff = (ulong)run2[processName][percentageProcessorTime] - (ulong)run1[processName][percentageProcessorTime];
    		ulong totalDiff = (ulong)run2[total][percentageProcessorTime] - (ulong)run1[total][percentageProcessorTime];
    
    		return ((float)percentageDiff / (float)totalDiff)*100.0f;
    	}
    
    }
