    var response = client.RunTask(new RunTaskRequest 
    {
        Cluster = "default",
        TaskDefinition = "sleep360:1"
        PlatformVersion = "LATEST",
        LaunchType = "FARGATE",
        NetworkConfiguration = new NetworkConfiguration
        {
            AwsvpcConfiguration = new AwsVpcConfiguration
            {
                Subnets = new List<string>() { "subnet-XXXXXXXX" },
                SecurityGroups = new List<string>() { "sg-XXXXXXXXXXXXXXXXX" },
                AssignPublicIp = AssignPublicIp.ENABLED
            }
        }
    });
