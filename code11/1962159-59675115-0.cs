    ActivityManager activityManager = GetSystemService(Context.ActivityService) as ActivityManager;
    ActivityManager.MemoryInfo memoryInfo = new ActivityManager.MemoryInfo();
    activityManager.GetMemoryInfo(memoryInfo);
    
    List<ActivityManager.RunningAppProcessInfo> runningAppProcesses = activityManager.RunningAppProcesses as List<ActivityManager.RunningAppProcessInfo>;
