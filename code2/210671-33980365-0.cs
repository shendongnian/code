	[__DynamicallyInvokable]
	public static DateTime UtcNow
	{
		[__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), SecuritySafeCritical]
		get
		{
			long systemTimeAsFileTime = DateTime.GetSystemTimeAsFileTime();
			return new DateTime((ulong)(systemTimeAsFileTime + 504911232000000000L | 4611686018427387904L));
		}
	}
