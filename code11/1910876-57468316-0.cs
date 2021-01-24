private void ReadCompleteCallback_NotApplicable(object handle, Opc.Da.ItemValueResult[] results)
{
    Console.WriteLine("Read completed.");
    foreach(Opc.Da.ItemValueResult readResult in results)
    {
        Console.WriteLine($"{readResult.ItemName}\tval:{readResult.Value}");
    }
}
So `readResult.Value` will contain the value you are looking for.
