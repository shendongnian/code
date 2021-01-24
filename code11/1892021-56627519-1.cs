    ActivityManager activityManager = (ActivityManager)BaseContext.GetSystemService(Context.ActivityService);
    ActivityManager.MemoryInfo memoryInfo = new ActivityManager.MemoryInfo();
    activityManager.GetMemoryInfo(memoryInfo);
    
    List<ActivityManager.RunningAppProcessInfo> runningAppProcesses = activityManager.RunningAppProcesses as List<ActivityManager.RunningAppProcessInfo>;
