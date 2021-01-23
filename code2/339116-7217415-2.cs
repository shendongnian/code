            //  TimeSpan system = sysKernelDiffenceTs.Add(sysUserDiffenceTs);
            //Double cpuUsage = (((system.Subtract(sysIdleDiffenceTs).TotalMilliseconds) * 100) / system.TotalMilliseconds); 
            TimeSpan totaltime = sysKernelDiffenceTs.Add(sysUserDiffenceTs);
            totaltime = totaltime.Add(sysIdleDifferenceTs);
            int cpuUsage = 100 - (sysIdleDifferenceTs.TotalMilliseconds * 100) / totaltime.TotalMilliseconds;
           Console.WriteLine("CPU: " + cpuUsage + "%");
