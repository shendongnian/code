    StringBuilder sbCpu = new StringBuilder();
    sbCpu.Append(Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS"));
    sbCpu.Append(" * ");
    sbCpu.Append(Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
    Console.Writeline(sbCpu.ToString());
