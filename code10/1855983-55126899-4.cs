    public static async void LaunchProcess(int groupId)
        {
            switch (groupId)
            {
                case 1:
                    await FullTrustProcessLauncher.LaunchFullTrustProcessForAppAsync("SomeGroup1");
                    break;
                case 2:
                    await FullTrustProcessLauncher.LaunchFullTrustProcessForAppAsync("SomeGroup2");
                    break;
            }
        }
